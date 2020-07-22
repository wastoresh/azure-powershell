﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using global::Azure;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// list azure blobs in specified azure container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobByTag"),OutputType(typeof(AzureStorageBlob))]
    public class GetAzureStorageBlobByTagCommand : StorageCloudBlobCmdletBase
    {
        [Parameter(HelpMessage = "This parameter enables the caller to query blobs whose tags match a given expression. " +
            "The given expression must evaluate to true for a blob to be returned in the results. " +
            "The [OData - ABNF] filter syntax rule defines the formal grammar for the value of the where query parameter; however, only a subset of the OData filter syntax is supported in the Blob service.",
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string TagFilterSqlExpression { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The max count of the blobs that can return.")]
        public int? MaxCount
        {
            get { return InternalMaxCount; }
            set
            {
                if (value.Value <= 0)
                {
                    InternalMaxCount = int.MaxValue;
                }
                else
                {
                    InternalMaxCount = value.Value;
                }
            }
        }

        private int InternalMaxCount = int.MaxValue;

        [Parameter(Mandatory = false, HelpMessage = "Continuation Token.")]
        public BlobContinuationToken ContinuationToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "As the blobs get by tag don't contain blob proeprties, specify tis parameter to get blob properties with an additional request on each blob.")]
        public SwitchParameter GetBlobProperty { get; set; }

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }
        protected override bool UseTrack2Sdk()
        {
            return true;
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobCommand class.
        /// </summary>
        public GetAzureStorageBlobByTagCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageBlobByTagCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// list blobs by blob Tag
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="prefix">blob preifx</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByTag(long taskId, IStorageBlobManagement localChannel, string tagFilterSqlExpression)
        {

            BlobServiceClient blobServiceClient = Util.GetTrack2BlobServiceClient(localChannel.StorageContext, ClientOptions);

            int listCount = InternalMaxCount;
            int MaxListCount = 5000;
            int requestCount = MaxListCount;
            int realListCount = 0;
            BlobContinuationToken continuationToken = ContinuationToken;
            string track2ContinuationToken = this.ContinuationToken is null ? null : this.ContinuationToken.NextMarker;

            do
            {
                requestCount = Math.Min(listCount, MaxListCount);
                realListCount = 0;
                IAsyncEnumerator<Page<BlobTagItem>> enumerator = blobServiceClient.FindBlobsByTagsAsync(tagFilterSqlExpression, CmdletCancellationToken)
                    .AsPages(track2ContinuationToken, requestCount)
                    .GetAsyncEnumerator();

                Page<BlobTagItem> page;
                await enumerator.MoveNextAsync().ConfigureAwait(false);
                page = enumerator.Current;
                foreach (BlobTagItem item in page.Values)
                {
                    //OutputStream.WriteObject(taskId, new AzureStorageBlob(item, Channel.StorageContext, page.ContinuationToken, ClientOptions));
                    OutputStream.WriteObject(taskId, new AzureStorageBlob(item, Channel.StorageContext, page.ContinuationToken, ClientOptions, this.GetBlobProperty.IsPresent));
                    realListCount++;
                }
                track2ContinuationToken = page.ContinuationToken;

                if (InternalMaxCount != int.MaxValue)
                {
                    listCount -= realListCount;
                }
            } while (listCount > 0 && !string.IsNullOrEmpty(track2ContinuationToken));
        }   

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;

            taskGenerator = (taskId) => ListBlobsByTag(taskId, localChannel, this.TagFilterSqlExpression);
    

            RunTask(taskGenerator);
        }
    }
}
