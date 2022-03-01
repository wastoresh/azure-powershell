// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Files.Shares;
    using Microsoft.WindowsAzure.Commands.Common;
    using global::Azure.Core;
    using global::Azure;
    using global::Azure.Storage.Files.Shares.Models;
    using System.Linq;

    public abstract class AzureStorageFileCmdletBase : StorageCloudCmdletBase<IStorageFileManagement>
    {
        //[Parameter(
        //    ValueFromPipeline = true,
        //    ValueFromPipelineByPropertyName = true,
        //    ParameterSetName = Constants.ShareNameParameterSetName,
        //    HelpMessage = "Azure Storage Context Object")]
        //public override IStorageContext Context { get; set; }

        protected FileRequestOptions RequestOptions
        {
            get
            {
                return (FileRequestOptions)this.GetRequestOptions(StorageServiceType.File);
            }
        }

        protected override IStorageFileManagement CreateChannel()
        {
            if (this.Channel == null || !this.ShareChannel)
            {
                try
                {
                    this.Channel = new StorageFileManagement(
                            this.GetCmdletStorageContext(outputErrorMessage: false)
                    );
                }
                catch (InvalidOperationException)
                {
                    this.Channel = new StorageFileManagement(
                        AzureStorageContext.EmptyContextInstance
                    );
                }

                // [Wei] this is caused before, only "ShareName" parameter set has parameter Context.
                //this.Channel = new StorageFileManagement(
                //    this.ParameterSetName == Constants.ShareNameParameterSetName ||
                //    this.ParameterSetName.StartsWith("ShareName") ||
                //    this.ParameterSetName == Constants.MatchingPrefixParameterSetName ||
                //    this.ParameterSetName == Constants.SpecificParameterSetName ?
                //        this.GetCmdletStorageContext() :
                //        AzureStorageContext.EmptyContextInstance
                //);
            }

            return this.Channel;
        }

        protected CloudFileShare BuildFileShareObjectFromName(string name)
        {
            NamingUtil.ValidateShareName(name, false);
            return this.Channel.GetShareReference(name);
        }

        protected bool ShareIsEmpty(CloudFileShare share)
        {
            try
            {
                FileContinuationToken fileToken = new FileContinuationToken();
                using (IEnumerator<IListFileItem> listedFiles = share.GetRootDirectoryReference()
                    .ListFilesAndDirectoriesSegmentedAsync(1, fileToken, RequestOptions, OperationContext).Result
                    .Results.GetEnumerator())
                {
                    return !(listedFiles.MoveNext() && listedFiles.Current != null);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool ShareIsEmpty(ShareClient share)
        {
            try
            {
                Pageable<ShareFileItem> listedFiles = share.GetRootDirectoryClient().GetFilesAndDirectories("", this.CmdletCancellationToken);
                if (listedFiles.AsPages(null, 1).First().Values.Count == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Write CloudFile to output using specified service channel
        /// </summary>
        /// <param name="file">The output CloudFile object</param>
        /// <param name="channel">IStorageFileManagement channel object</param>
        internal void WriteCloudFileObject(long taskId, IStorageFileManagement channel, CloudFile file)
        {
            AzureStorageFile azureFile = new AzureStorageFile(file, channel.StorageContext);
            OutputStream.WriteObject(taskId, azureFile);
        }


        /// <summary>
        /// Write CloudFileDirectory to output using specified service channel
        /// </summary>
        /// <param name="fileDir">The output CloudFileDirectory object</param>
        /// <param name="channel">IStorageFileManagement channel object</param>
        internal void WriteCloudFileDirectoryeObject(long taskId, IStorageFileManagement channel, CloudFileDirectory fileDir)
        {
            AzureStorageFileDirectory azureFileDir = new AzureStorageFileDirectory(fileDir, channel.StorageContext);
            OutputStream.WriteObject(taskId, azureFileDir);
        }

        /// <summary>
        /// Write CloudFileShare to output using specified service channel
        /// </summary>
        /// <param name="share">The output CloudFileShare object</param>
        /// <param name="channel">IStorageFileManagement channel object</param>
        internal void WriteCloudShareObject(long taskId, IStorageFileManagement channel, CloudFileShare share)
        {
            AzureStorageFileShare azureshare = new AzureStorageFileShare(share, channel.StorageContext);
            OutputStream.WriteObject(taskId, azureshare);
        }

        internal AzureStorageFileShare GetOutputShareObject(IStorageFileManagement channel, CloudFileShare share, ShareClient shareClient)
        {
            if (channel.StorageContext != null && channel.StorageContext.StorageAccount != null)
            {
                return new AzureStorageFileShare(shareClient, channel.StorageContext, clientOptions: ClientOptions);
            }
            else
            {
                return new AzureStorageFileShare(share, channel.StorageContext);
            }
        }

        /// <summary>
        /// Write IListFileItem to output using specified service channel
        /// </summary>
        /// <param name="item">The output IListFileItem object</param>
        /// <param name="channel">IStorageFileManagement channel object</param>
        internal void WriteListFileItemObject(long taskId, IStorageFileManagement channel, IListFileItem item)
        {
            if ((item as CloudFile) != null) // CloudFile
            {
                WriteCloudFileObject(taskId, channel, item as CloudFile);
            }
            else
            {
                WriteCloudFileDirectoryeObject(taskId, channel, item as CloudFileDirectory);
            }
        }

        public ShareClientOptions ClientOptions
        {
            get
            {
                if (clientOptions == null)
                {
                    clientOptions = new ShareClientOptions();
                    clientOptions.AddPolicy(new UserAgentPolicy(ApiConstants.UserAgentHeaderValue), HttpPipelinePosition.PerCall);
                    return clientOptions;
                }
                else
                {
                    return clientOptions;
                }
            }
        }
        private ShareClientOptions clientOptions = null;
    }
}
