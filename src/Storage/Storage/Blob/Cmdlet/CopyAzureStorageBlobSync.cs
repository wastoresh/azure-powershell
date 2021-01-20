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

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Adapters;
    using Azure.Commands.Common.Authentication.Abstractions;
    using Commands.Common;
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.File;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using global::Azure.Storage.Blobs.Specialized;
    using global::Azure.Storage.Blobs;
    using Track2Models = global::Azure.Storage.Blobs.Models;
    using System.Collections;
    using System.Linq;

    [Cmdlet("Copy", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobCopy", SupportsShouldProcess = true, DefaultParameterSetName = ContainerNameParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class CopyAzureStorageBlob : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobParameterSet = "BlobInstance";

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobToBlobParameterSet = "BlobInstanceToBlobInstance";

        /// <summary>
        /// Container pipeline paremeter set name
        /// </summary>
        private const string ContainerParameterSet = "ContainerInstance";

        /// <summary>
        /// Blob name and container name parameter set
        /// </summary>
        private const string ContainerNameParameterSet = "ContainerName";

        /// <summary>
        /// Source uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Alias("SourceCloudBlobContainer")]
        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        public BlobContainerClient BlobContainerClient { get; set; }

        [Parameter(HelpMessage = "Destiantion Blob Type('Block', 'Page', 'Append'), by default will be same as source.")]
        [ValidateSet(BlockBlobType, PageBlobType, AppendBlobType, IgnoreCase = true)]
        public string DestBlobType
        {
            get { return blobType; }
            set { blobType = value; }
        }
        private string blobType = BlockBlobType;

        [Alias("SourceBlob")]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerParameterSet, Mandatory = true, Position = 0)]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerNameParameterSet, Mandatory = true, Position = 0)]
        public string SrcBlob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Alias("SourceContainer")]
        [Parameter(HelpMessage = "Source Container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainer
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Alias("SrcUri", "SourceUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Alias("DestinationContainer")]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        public string DestContainer { get; set; }

        [Alias("DestinationBlob")]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        public string DestBlob { get; set; }

        [Alias("DestICloudBlob", "DestinationCloudBlob", "DestinationICloudBlob")]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = BlobToBlobParameterSet)]
        //[Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = FileToBlobParameterSet)]
        public CloudBlob DestCloudBlob { get; set; }

        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        public PremiumPageBlobTier PremiumPageBlobTier
        {
            get
            {
                return pageBlobTier.Value;
            }

            set
            {
                pageBlobTier = value;
            }
        }
        private PremiumPageBlobTier? pageBlobTier = null;

        [Parameter(HelpMessage = "Block Blob Tier, valid values are Hot/Cool/Archive. See detail in https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers", Mandatory = false)]
        [PSArgumentCompleter("Hot", "Cool", "Archive")]
        [ValidateSet("Hot", "Cool", "Archive", IgnoreCase = true)]
        public string StandardBlobTier
        {
            get
            {
                return standardBlobTier is null ? null : standardBlobTier.Value.ToString();
            }

            set
            {
                if (value != null)
                {
                    standardBlobTier = ((StandardBlobTier)Enum.Parse(typeof(StandardBlobTier), value, true));
                }
                else
                {
                    standardBlobTier = null;
                }
            }
        }
        private StandardBlobTier? standardBlobTier = null;

        [Parameter(HelpMessage = "Block Blob RehydratePriority. Indicates the priority with which to rehydrate an archived blob. Valid values are High/Standard.", Mandatory = false)]
        [ValidateSet("Standard", "High", IgnoreCase = true)]
        public Azure.Storage.Blob.RehydratePriority RehydratePriority
        {
            get
            {
                return rehydratePriority.Value;
            }

            set
            {
                rehydratePriority = value;
            }
        }
        private Azure.Storage.Blob.RehydratePriority? rehydratePriority = null;

        [Alias("SrcContext", "SourceContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ParameterSetName = UriParameterSet)]
        public override IStorageContext Context { get; set; }

        [Alias("DestinationContext")]
        [Parameter(HelpMessage = "Destination Storage context object", Mandatory = false)]
        public IStorageContext DestContext { get; set; }

        public override SwitchParameter AsJob { get; set; }

        private bool skipSourceChannelInit;

        /// <summary>
        /// Create blob client and storage service management channel if need to.
        /// </summary>
        /// <returns>IStorageManagement object</returns>
        protected override IStorageBlobManagement CreateChannel()
        {
            //Init storage blob management channel
            if (skipSourceChannelInit)
            {
                return null;
            }
            else
            {
                return base.CreateChannel();
            }
        }

        /// <summary>
        /// Begin cmdlet processing
        /// </summary>
        protected override void BeginProcessing()
        {
            if (ParameterSetName == UriParameterSet)
            {
                skipSourceChannelInit = true;
            }

            base.BeginProcessing();
        }

        private IStorageFileManagement GetFileChannel()
        {
            return new StorageFileManagement(GetCmdletStorageContext());
        }

        /// <summary>
        /// Set up the Channel object for Destination container and blob
        /// </summary>
        internal IStorageBlobManagement GetDestinationChannel()
        {
            //If destChannel exits, reuse it.
            //If desContext exits, use it.
            //If Channl object exists, use it.
            //Otherwise, create a new channel.
            IStorageBlobManagement destChannel = default(IStorageBlobManagement);

            if (destChannel == null)
            {
                if (DestContext == null)
                {
                    if (Channel != null)
                    {
                        destChannel = Channel;
                    }
                    else
                    {
                        destChannel = base.CreateChannel();
                    }
                }
                else
                {
                    destChannel = CreateChannel(this.GetCmdletStorageContext(DestContext));
                }
            }

            return destChannel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement destChannel = GetDestinationChannel();
            IStorageBlobManagement srcChannel = Channel;

            string target = string.Empty;
            Action copyAction = null;
            switch (ParameterSetName)
            {
                case ContainerNameParameterSet:
                    copyAction = () => CopyBlobSync(srcChannel, destChannel, SrcContainer, SrcBlob, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case UriParameterSet:
                    copyAction = () => CopyBlobSync(destChannel, AbsoluteUri, DestContainer, DestBlob, (Context != null ? GetCmdletStorageContext(Context) : null));
                    target = AbsoluteUri;
                    break;

                case BlobParameterSet:
                    copyAction = () => CopyBlobSync(destChannel, BlobBaseClient, DestContainer, DestBlob);
                    target = BlobBaseClient.Name;
                    break;

                case ContainerParameterSet:
                    copyAction = () => CopyBlobSync(srcChannel, destChannel, BlobContainerClient.Name, SrcBlob, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case BlobToBlobParameterSet:
                    BlobBaseClient destBlobClient = AzureStorageBlob.GetTrack2BlobClient(DestCloudBlob, destChannel.StorageContext, ClientOptions);
                    copyAction = () => CopyBlobSync(destChannel, BlobBaseClient, destBlobClient);
                    target = BlobBaseClient.Name;
                    break;
            }

            if (copyAction != null && ShouldProcess(target, VerbsCommon.Copy))
            {
                copyAction();
            }
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, BlobBaseClient destCloudBlob)
        {
            global::Azure.Storage.Blobs.Models.BlobType srcBlobType = Util.GetBlobType(srcCloudBlob, true).Value;
            if (srcCloudBlob is BlobClient)
            {
                srcCloudBlob = Util.GetTrack2BlobClientWithType(srcCloudBlob, Channel.StorageContext, srcBlobType);
            }
            if (destCloudBlob is BlobClient)
            {
                destCloudBlob = Util.GetTrack2BlobClientWithType(destCloudBlob, destChannel.StorageContext, srcBlobType);
            }
            ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(srcBlobType), pageBlobTier, standardBlobTier, rehydratePriority);

            Func<long, Task> taskGenerator = (taskId) => StartCopyAsync(taskId, destChannel, srcCloudBlob, destCloudBlob);
            RunTask(taskGenerator);
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, string destContainer, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcCloudBlob.Name;
            }

            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, Util.GetBlobType(srcCloudBlob));

            this.CopyBlobSync(destChannel, srcCloudBlob, destBlob);
        }

        /// <summary>
        /// Start copy operation by source uri
        /// </summary>
        /// <param name="srcCloudBlob">Source uri</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void CopyBlobSync(IStorageBlobManagement destChannel, string srcUri, string destContainer, string destBlobName, AzureStorageContext context)
        {
            //if (context != null)
            //{
            //    Uri sourceUri = new Uri(srcUri);
            //    Uri contextUri = new Uri(context.BlobEndPoint);

            //    if (sourceUri.Host.ToLower() == contextUri.Host.ToLower())
            //    {
            //        CloudBlobClient blobClient = context.StorageAccount.CreateCloudBlobClient();
            //        CloudBlob blobReference = null;
            //        BlobBaseClient srcBlobBaseClient = new BlobBaseClient(new Uri(srcUri));

            //        try
            //        {
            //            blobReference = Util.GetBlobReferenceFromServer(blobClient, sourceUri);
            //        }
            //        catch (InvalidOperationException)
            //        {
            //            blobReference = null;
            //        }

            //        if (null == blobReference)
            //        {
            //            throw new ResourceNotFoundException(String.Format(Resources.BlobUriNotFound, sourceUri.ToString()));
            //        }

            //        CopyBlobSync(destChannel, blobReference, destContainer, destBlobName);
            //    }
            //    else
            //    {
            //        WriteWarning(String.Format(Resources.StartCopySourceContextMismatch, srcUri, context.BlobEndPoint));
            //    }
            //}
            //else
            //{

            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, Util.GetBlobType(new BlobBaseClient(new Uri(srcUri), ClientOptions)));
            Func<long, Task> taskGenerator = (taskId) => CopyFromUri(taskId, destChannel, new Uri(srcUri), destBlob);
                RunTask(taskGenerator);
            //}
        }

        /// <summary>
        /// Start copy operation by container name and blob name
        /// </summary>
        /// <param name="srcContainerName">Source container name</param>
        /// <param name="srcBlobName">Source blob name</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void CopyBlobSync(IStorageBlobManagement SrcChannel, IStorageBlobManagement destChannel, string srcContainerName, string srcBlobName, string destContainerName, string destBlobName)
        {
            NameUtil.ValidateBlobName(srcBlobName);
            NameUtil.ValidateContainerName(srcContainerName);
            NameUtil.ValidateContainerName(destContainerName);

            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcBlobName;
            }

            BlobBaseClient srcBlobBaseClient = Util.GetTrack2BlobServiceClient(SrcChannel.StorageContext, ClientOptions).GetBlobContainerClient(srcContainerName).GetBlobBaseClient(srcBlobName);
            BlobBaseClient destBlobBaseClient = Util.GetTrack2BlobServiceClient(destChannel.StorageContext, ClientOptions).GetBlobContainerClient(destContainerName).GetBlobBaseClient(destBlobName);


            this.CopyBlobSync(destChannel, srcBlobBaseClient, destBlobBaseClient);
        }     

        private async Task StartCopyFromBlob(long taskId, IStorageBlobManagement destChannel, BlobBaseClient srcBlob, BlobBaseClient destBlob)
        {
            //try
            //{
                await CopyFromUri(taskId, destChannel, srcBlob.GenerateUriWithCredentials(Channel.StorageContext), destBlob).ConfigureAwait(false);
            //}
            //catch (StorageException ex)
            //{
            //    if (0 == string.Compare(ex.Message, BlobTypeMismatch, StringComparison.OrdinalIgnoreCase))
            //    {
            //        // Current use error message to decide whether it caused by blob type mismatch,
            //        // We should ask xscl to expose an error code for this..
            //        // Opened workitem 1487579 to track this.
            //        throw new InvalidOperationException(Resources.DestinationBlobTypeNotMatch);
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        private async Task CopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, BlobBaseClient destBlob)
        {
            bool destExist = true;
            Track2Models.BlobType? destBlobType = Util.GetBlobType(destBlob);
            Track2Models.BlobProperties properties = null;

            try
            {
                properties = (await destBlob.GetPropertiesAsync(this.BlobRequestConditions, cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false)).Value;
                destBlobType = properties.BlobType;
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 404)
            {
                destExist = false;
            }
            if (destBlobType != null)
            {
                ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(destBlobType), null, standardBlobTier, rehydratePriority);
            }

            if (!destExist || this.ConfirmOverwrite(srcUri.AbsoluteUri.ToString(), destBlob.Uri.ToString()))
            {
                Track2Models.BlobCopyFromUriOptions options = new global::Azure.Storage.Blobs.Models.BlobCopyFromUriOptions();

                // The Blob Type and Blob Tier must match, since already checked they are match at the begin of ExecuteCmdlet().
                if (pageBlobTier != null)
                {
                    options.AccessTier = Util.ConvertAccessTier_Track1ToTrack2(pageBlobTier);
                }
                else
                if (standardBlobTier != null || rehydratePriority != null)
                {
                    options.AccessTier = Util.ConvertAccessTier_Track1ToTrack2(standardBlobTier);
                    options.RehydratePriority = Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority);
                }
                options.SourceConditions = this.BlobRequestConditions;

                Track2Models.BlobCopyInfo blobCopyInfo = await destBlob.SyncCopyFromUriAsync(srcUri, options, this.CmdletCancellationToken).ConfigureAwait(false);

                OutputStream.WriteObject(taskId, new AzureStorageBlob(destBlob, destChannel.StorageContext, properties, options: ClientOptions));
            }
        }

        private BlobBaseClient GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName, global::Azure.Storage.Blobs.Models.BlobType? blobType)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(destChannel.GetContainerReference(destContainerName), destChannel.StorageContext, ClientOptions);
            BlobBaseClient destBlob = Util.GetTrack2BlobClient(container, destBlobName, destChannel.StorageContext, null, null, null, ClientOptions, blobType is null ? global::Azure.Storage.Blobs.Models.BlobType.Block : blobType.Value);
            return destBlob;
        }

        private async Task StartCopyAsync(long taskId, IStorageBlobManagement destChannel, BlobBaseClient sourceBlob, BlobBaseClient destBlob)
        {
            NameUtil.ValidateBlobName(sourceBlob.Name);
            NameUtil.ValidateContainerName(destBlob.BlobContainerName);
            NameUtil.ValidateBlobName(destBlob.Name);

            await this.StartCopyFromBlob(taskId, destChannel, sourceBlob, destBlob).ConfigureAwait(false);
        }

    }
}
