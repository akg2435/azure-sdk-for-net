// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for FileServersOperations.
    /// </summary>
    public static partial class FileServersOperationsExtensions
    {
            /// <summary>
            /// Creates a File Server in the given workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for File Server creation.
            /// </param>
            public static FileServer Create(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, FileServerCreateParameters parameters)
            {
                return operations.CreateAsync(resourceGroupName, workspaceName, fileServerName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a File Server in the given workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for File Server creation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<FileServer> CreateAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, FileServerCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServerName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            public static void Delete(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName)
            {
                operations.DeleteAsync(resourceGroupName, workspaceName, fileServerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServerName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets information about a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            public static FileServer Get(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName)
            {
                return operations.GetAsync(resourceGroupName, workspaceName, fileServerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets information about a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<FileServer> GetAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of File Servers associated with the specified workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServersListByWorkspaceOptions'>
            /// Additional parameters for the operation
            /// </param>
            public static IPage<FileServer> ListByWorkspace(this IFileServersOperations operations, string resourceGroupName, string workspaceName, FileServersListByWorkspaceOptions fileServersListByWorkspaceOptions = default(FileServersListByWorkspaceOptions))
            {
                return operations.ListByWorkspaceAsync(resourceGroupName, workspaceName, fileServersListByWorkspaceOptions).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of File Servers associated with the specified workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServersListByWorkspaceOptions'>
            /// Additional parameters for the operation
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<FileServer>> ListByWorkspaceAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, FileServersListByWorkspaceOptions fileServersListByWorkspaceOptions = default(FileServersListByWorkspaceOptions), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByWorkspaceWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServersListByWorkspaceOptions, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a File Server in the given workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for File Server creation.
            /// </param>
            public static FileServer BeginCreate(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, FileServerCreateParameters parameters)
            {
                return operations.BeginCreateAsync(resourceGroupName, workspaceName, fileServerName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a File Server in the given workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='parameters'>
            /// The parameters to provide for File Server creation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<FileServer> BeginCreateAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, FileServerCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServerName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            public static void BeginDelete(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName)
            {
                operations.BeginDeleteAsync(resourceGroupName, workspaceName, fileServerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes a File Server.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Name of the resource group to which the resource belongs.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace. Workspace names can only contain a combination
            /// of alphanumeric characters along with dash (-) and underscore (_). The name
            /// must be from 1 through 64 characters long.
            /// </param>
            /// <param name='fileServerName'>
            /// The name of the file server within the specified resource group. File
            /// server names can only contain a combination of alphanumeric characters
            /// along with dash (-) and underscore (_). The name must be from 1 through 64
            /// characters long.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IFileServersOperations operations, string resourceGroupName, string workspaceName, string fileServerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, workspaceName, fileServerName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Gets a list of File Servers associated with the specified workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<FileServer> ListByWorkspaceNext(this IFileServersOperations operations, string nextPageLink)
            {
                return operations.ListByWorkspaceNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of File Servers associated with the specified workspace.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<FileServer>> ListByWorkspaceNextAsync(this IFileServersOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByWorkspaceNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
