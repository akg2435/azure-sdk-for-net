﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.QuickQuery.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.QuickQuery.Tests
{
    public class QuickQueryClientTests : QuickQueryTestBase
    {
        public QuickQueryClientTests(bool async) : this(async, null) { }

        public QuickQueryClientTests(bool async, RecordedTestMode? mode = null)
            : base(async, mode) { }

        [Test]
        public async Task QueryAsync_Min()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            BlobQuickQueryClient queryClient = blockBlobClient.GetQuickQueryClient();
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            Response<BlobDownloadInfo> response =  await queryClient.QueryAsync(query);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.AreEqual("400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n", s);
        }

        [Test]
        //TODO mark this as ignore
        public async Task QueryAsync_Large()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(16 * Constants.MB);
            await blockBlobClient.UploadAsync(stream);

            BlobQuickQueryClient queryClient = blockBlobClient.GetQuickQueryClient();
            string query = @"SELECT * from BlobStorage";

            // Act
            TestProgress progressReporter = new TestProgress();
            Response<BlobDownloadInfo> response = await queryClient.QueryAsync(
                query,
                progressReceiver: progressReporter);

            stream.Seek(0, SeekOrigin.Begin);
            using StreamReader expectedStreamReader = new StreamReader(stream);
            string expected = await expectedStreamReader.ReadToEndAsync();

            using StreamReader actualStreamReader = new StreamReader(response.Value.Content);
            string actual = await actualStreamReader.ReadToEndAsync();

            // Assert
            // Check we got back the same content that we uploaded.
            Assert.AreEqual(expected, actual);

            // Check progress reporter
            Assert.AreEqual(4, progressReporter.List.Count);
            Assert.AreEqual(4 * Constants.MB, progressReporter.List[0]);
            Assert.AreEqual(8 * Constants.MB, progressReporter.List[1]);
            Assert.AreEqual(12 * Constants.MB, progressReporter.List[2]);
            Assert.AreEqual(16 * Constants.MB, progressReporter.List[3]);
        }

        [Test]
        public async Task QueryAsync_Progress()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            BlobQuickQueryClient queryClient = blockBlobClient.GetQuickQueryClient();
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            TestProgress progressReporter = new TestProgress();

            Response<BlobDownloadInfo> response = await queryClient.QueryAsync(
                query,
                progressReceiver: progressReporter);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            await streamReader.ReadToEndAsync();

            Assert.AreEqual(1, progressReporter.List.Count);
            Assert.AreEqual(Constants.KB, progressReporter.List[0]);
        }

        [Test]
        public async Task QueryAsync_NonFatalError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = Encoding.UTF8.GetBytes("100,pizza,300,400\n300,400,500,600\n");
            using MemoryStream stream = new MemoryStream(data);
            await blockBlobClient.UploadAsync(stream);

            BlobQuickQueryClient queryClient = blockBlobClient.GetQuickQueryClient();
            string query = @"SELECT _1 from BlobStorage WHERE _2 > 250;";

            // Act - with no IBlobQueryErrorReceiver
            Response<BlobDownloadInfo> response = await queryClient.QueryAsync(query);
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();


            // Act - with  IBlobQueryErrorReceiver
            BlobQueryError expectedBlobQueryError = new BlobQueryError
            {
                IsFatal = false,
                Name = "InvalidTypeConversion",
                Description = "Invalid type conversion",
                Position = 0
            };

            response = await queryClient.QueryAsync(
                query,
                nonFatalErrorReceiver: new NonFatalErrorReceiver(expectedBlobQueryError));
            using StreamReader streamReader2 = new StreamReader(response.Value.Content);
            s = await streamReader2.ReadToEndAsync();
        }

        [Test]
        public async Task QueryAsync_FatalError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            BlobQuickQueryClient queryClient = blockBlobClient.GetQuickQueryClient();
            string query = @"SELECT * from BlobStorage;";
            JsonTextConfiguration jsonTextConfiguration = new JsonTextConfiguration
            {
                RecordSeparator = '\n'
            };

            // Act
            Response<BlobDownloadInfo> response = await queryClient.QueryAsync(
                query,
                inputTextConfiguration: jsonTextConfiguration);

            using StreamReader streamReader = new StreamReader(response.Value.Content);

            TestHelper.AssertExpectedException<RequestFailedException>(
                () => streamReader.ReadToEnd(),
                new RequestFailedException("Fatal Quick Query Error\nName: ParseError\nDescription: Unexpected token ',' at [byte: 3]. Expecting tokens '{', or '['.\nPosition: 0"));
        }

        private Stream CreateDataStream(long size)
        {
            MemoryStream stream = new MemoryStream();
            byte[] rowData = Encoding.UTF8.GetBytes("100,200,300,400\n300,400,500,600\n");
            long blockLength = 0;
            while (blockLength < size)
            {
                stream.Write(rowData, 0, rowData.Length);
                blockLength += rowData.Length;
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        private class NonFatalErrorReceiver : IBlobQueryErrorReceiver
        {
            private readonly BlobQueryError _expectedBlobQueryError;

            public NonFatalErrorReceiver(BlobQueryError expected)
            {
                _expectedBlobQueryError = expected;
            }

            public void ReportError(BlobQueryError blobQueryError)
            {
                Assert.IsFalse(blobQueryError.IsFatal);
                Assert.AreEqual(_expectedBlobQueryError.Name, blobQueryError.Name);
                Assert.AreEqual(_expectedBlobQueryError.Description, blobQueryError.Description);
                Assert.AreEqual(_expectedBlobQueryError.Position, blobQueryError.Position);
            }
        }
    }
}
