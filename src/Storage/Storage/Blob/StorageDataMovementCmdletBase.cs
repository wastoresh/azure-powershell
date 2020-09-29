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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using global::Azure.Storage.DataMovement;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using OpContext = Microsoft.Azure.Storage.OperationContext;

    public class StorageDataMovementCmdletBase : StorageCloudBlobCmdletBase, IDisposable
    {
        protected const int size4MB = 4 * 1024 * 1024;

        /// <summary>
        /// Blob Transfer Manager
        /// </summary>
        protected ITransferManager TransferManager
        {
            get;
            private set;
        }

        [Parameter(HelpMessage = "Force to overwrite the existing blob or file")]
        public SwitchParameter Force
        {
            get { return overwrite; }
            set { overwrite = value; }
        }

        protected bool overwrite;

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        public string ResolvedFileName { get; set; }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="msg">Confirmation message</param>
        /// <returns>True if the opeation is confirmed, otherwise return false</returns>
        protected bool ConfirmOverwrite(object source, object destination)
        {
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination));
            return overwrite || OutputStream.ConfirmAsync(overwriteMessage).Result;
        }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="msg">Confirmation message</param>
        /// <returns>True if the opeation is confirmed, otherwise return false</returns>
        /// public delegate bool ShouldTransferCallback(object source, object destination);
        protected bool ConfirmOverwriteAsync(object source, object destination)
        {
            if (overwrite)
            {
                return true;
            }
            
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination));
            Task<bool> confirmTask = OutputStream.ConfirmAsync(overwriteMessage);
            confirmTask.Wait();
            return confirmTask.Result;
        }

        /// <summary>
        /// On Task run successfully
        /// </summary>
        /// <param name="data">User data</param>
        protected virtual void OnTaskSuccessful(DataMovementUserData data)
        { }


        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            DoBeginProcessing();
        }

        protected virtual void DoBeginProcessing()
        {
            CmdletOperationContext.Init();
            CmdletCancellationToken = _cancellationTokenSource.Token;
            WriteDebugLog(String.Format(Resources.InitOperationContextLog, GetType().Name, CmdletOperationContext.ClientRequestId));

            if (_enableMultiThread)
            {
                SetUpMultiThreadEnvironment();
            }

            OpContext.GlobalSendingRequest +=
                (sender, args) =>
                {
                    //https://github.com/Azure/azure-storage-net/issues/658
                };

            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);

            this.TransferManager = TransferManagerFactory.CreateTransferManager(this.GetCmdletConcurrency());
        }

        protected TransferContext GetTransferContext(DataMovementUserData userData)
        {
            TransferContext transferContext = new TransferContext();
            //transferContext.ClientRequestId = CmdletOperationContext.ClientRequestId;
            //if (overwrite)
            //{
            //    transferContext.ShouldOverwriteCallbackAsync = TransferContext.ForceOverwrite;
            //}
            //else
            //{
            //    transferContext.ShouldOverwriteCallbackAsync = ConfirmOverwriteAsync;
            //}

            transferContext.ProgressHandler = new TransferProgressHandler((transferProgress) =>
            {
                if (userData.Record != null)
                {
                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                    userData.Record.PercentComplete = 0 == userData.TotalSize ? 100 : (int)(transferProgress.BytesTransferred * 100 / userData.TotalSize);
                    userData.Record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, userData.Record.PercentComplete);
                    this.OutputStream.WriteProgress(userData.Record);
                }
            });

            return transferContext;
        }

        protected TransferOptions GetTransferOptions(DataMovementUserData userData)
        {
            TransferOptions transferOptions= new TransferOptions();
            //transferOptions.ClientRequestId = CmdletOperationContext.ClientRequestId;
            if (overwrite)
            {
                transferOptions.ShouldTransferOptions = ShouldTransferOptions.YesForAll;
            }
            else
            {
                transferOptions.ShouldTransferOptions = ShouldTransferOptions.NoIfDestinationExists;
                transferOptions.ShouldTransferCallback = ConfirmOverwriteAsync;
            }

            return transferOptions;
        }

        protected override void EndProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected virtual void DoEndProcessing()
        {
            try
            {
                base.EndProcessing();
                WriteTaskSummary();
            }
            finally
            {
                this.TransferManager = null;
            }
        }

        public static TransferBlob GetTransferBlob(Azure.Storage.Blob.CloudBlob blob, AzureStorageContext storageContext)
        {
            TransferBlobType blobtype = TransferBlobType.Unspecified;
            if (blob is Azure.Storage.Blob.CloudBlockBlob || blob.Properties.BlobType == Azure.Storage.Blob.BlobType.BlockBlob)
            {
                blobtype = TransferBlobType.BlockBlob;
            }
            else if (blob is Azure.Storage.Blob.CloudPageBlob || blob.Properties.BlobType == Azure.Storage.Blob.BlobType.PageBlob)
            {
                blobtype = TransferBlobType.PageBlob;
            }
            if (blob is Azure.Storage.Blob.CloudAppendBlob || blob.Properties.BlobType == Azure.Storage.Blob.BlobType.AppendBlob)
            {
                blobtype = TransferBlobType.AppendBlob;
            }

            TransferCredentials credentail = null;
            if (storageContext.StorageAccount.Credentials.IsSharedKey)
            {
                credentail = new TransferCredentials(storageContext.StorageAccount.ToString(), AuthenticationScheme.SharedKey);
            }
            else if (storageContext.StorageAccount.Credentials.IsSAS)
            {
                credentail = new TransferCredentials(storageContext.StorageAccount.ToString(), AuthenticationScheme.SASToken);
            }
            return new TransferBlob(blob.Uri, credentail, blobtype);
        }

        public static TransferBlob GetTransferBlob(global::Azure.Storage.Blobs.Specialized.BlobBaseClient blob, AzureStorageContext storageContext)
        {
            TransferBlobType blobtype = TransferBlobType.Unspecified;
            if (blob is global::Azure.Storage.Blobs.Specialized.BlockBlobClient)
            {
                blobtype = TransferBlobType.BlockBlob;
            }
            else if (blob is global::Azure.Storage.Blobs.Specialized.PageBlobClient)
            {
                blobtype = TransferBlobType.PageBlob;
            }
            if (blob is global::Azure.Storage.Blobs.Specialized.AppendBlobClient)
            {
                blobtype = TransferBlobType.AppendBlob;
            }

            TransferCredentials credentail = null;
            if (storageContext.StorageAccount.Credentials.IsSharedKey)
            {
                credentail = new TransferCredentials(storageContext.StorageAccount.ToString(), AuthenticationScheme.SharedKey);
            }
            else if (storageContext.StorageAccount.Credentials.IsSAS)
            {
                // For SAS, blob Uri already contains SAS credentail.
            }
            return new TransferBlob(blob.Uri, credentail, blobtype);
        }
    }
}
