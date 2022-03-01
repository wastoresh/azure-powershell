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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Files.Shares;
    using System;
    using global::Azure.Storage.Files.Shares.Models;

    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare",DefaultParameterSetName = Constants.ShareNameParameterSetName,SupportsShouldProcess = true), OutputType(typeof(AzureStorageFileShare))]
    public class RemoveAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share object to be removed.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(HelpMessage = "Remove File Share with all of its snapshots")]
        public SwitchParameter IncludeAllSnapshot { get; set; }

        [Parameter(HelpMessage = "Force to remove the share with all its snapshots, and all content in them.")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }

        [Parameter(HelpMessage = "Returns an object representing the removed file share. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        private bool force;

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);
        }

        public override void ExecuteCmdlet()
        {
            ShareClient shareClient;
            switch (this.ParameterSetName)
            {
                case Constants.ShareParameterSetName:
                    shareClient = AzureStorageFileShare.GetTrack2FileShareClient(this.Share, (AzureStorageContext)this.Context, ClientOptions);
                    break;

                case Constants.ShareNameParameterSetName:
                    shareClient = Util.GetTrack2ShareReference(this.Name,
                        (AzureStorageContext)this.Context,
                        null,
                        ClientOptions);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(shareClient.Name, "Remove share"))
            {
                DateTimeOffset? shareSnapshotTime = Util.GetSnapshotTimeFromUri(shareClient.Uri);
                if (shareSnapshotTime != null // share is snapshot
                    && IncludeAllSnapshot.IsPresent)
                {
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share '{0}' with snapshot time '{1}'.", shareClient.Name, shareSnapshotTime));
                }

                if (force || ShareIsEmpty(shareClient) || ShouldContinue(string.Format("Remove share and all content in it: {0}", shareClient.Name), ""))
                {
                    ShareDeleteOptions deleteOptions = new ShareDeleteOptions();
                    bool retryDeleteSnapshot = false;

                    //Force means will delete the share anyway, so use 'IncludeSnapshots' to delete the share even has snapshot, or delete will fail when share has snapshot
                    // To delete a Share shapshot, must use 'None' 
                    if (IncludeAllSnapshot.IsPresent)
                    {
                        deleteOptions.ShareSnapshotsDeleteOption = ShareSnapshotsDeleteOption.Include;
                    }
                    else
                    {
                        retryDeleteSnapshot = true;
                    }

                    try
                    {
                        if (deleteOptions != null && deleteOptions.ShareSnapshotsDeleteOption != null)
                        {
                            shareClient.Delete(deleteOptions, this.CmdletCancellationToken);
                        }
                        else
                        {
                            shareClient.Delete(includeSnapshots: false, cancellationToken: this.CmdletCancellationToken);
                        }
                        retryDeleteSnapshot = false;
                    }
                    catch (global::Azure.RequestFailedException e) when (e.Status == 409)
                    {
                        //If x-ms-delete-snapshots is not specified on the request and the share has associated snapshots, the File service returns status code 409 (Conflict).
                        if (!retryDeleteSnapshot)
                        {
                            throw;
                        }
                    }
                    if (retryDeleteSnapshot)
                    {
                        if (force || ShouldContinue(string.Format("This share might have snapshots or leased snapshots, remove the share and all snapshots?: {0}", shareClient.Name), ""))
                        {
                            deleteOptions.ShareSnapshotsDeleteOption = ShareSnapshotsDeleteOption.IncludeWithLeased;
                            shareClient.Delete(deleteOptions, this.CmdletCancellationToken);
                        }
                        else
                        {
                            string result = string.Format("The remove operation of share '{0}' has been cancelled.", shareClient.Name);
                            WriteVerbose(result);
                        }
                    }


                    if (this.PassThru)
                    {
                        WriteObject(GetOutputShareObject(this.Channel, this.Share, shareClient));
                    }

                    //this.RunTask(async taskId =>
                    //{
                    //    if (share.IsSnapshot && IncludeAllSnapshot.IsPresent)
                    //    {
                    //        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot: {0}", share.SnapshotQualifiedUri));
                    //    }

                    //    if (force || ShareIsEmpty(share) || ShouldContinue(string.Format("Remove share and all content in it: {0}", share.Name), ""))
                    //    {
                    //        DeleteShareSnapshotsOption deleteShareSnapshotsOption = DeleteShareSnapshotsOption.None;
                    //        bool retryDeleteSnapshot = false;

                    //        //Force means will delete the share anyway, so use 'IncludeSnapshots' to delete the share even has snapshot, or delete will fail when share has snapshot
                    //        // To delete a Share shapshot, must use 'None' 
                    //        if (IncludeAllSnapshot.IsPresent)
                    //        {
                    //            deleteShareSnapshotsOption = DeleteShareSnapshotsOption.IncludeSnapshots;
                    //        }
                    //        else
                    //        {
                    //            retryDeleteSnapshot = true;
                    //        }

                    //        try
                    //        {
                    //            await this.Channel.DeleteShareAsync(share, deleteShareSnapshotsOption, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    //            retryDeleteSnapshot = false;
                    //        }
                    //        catch (StorageException e)
                    //        {
                    //            //If x-ms-delete-snapshots is not specified on the request and the share has associated snapshots, the File service returns status code 409 (Conflict).
                    //            if (!(e.IsConflictException() && retryDeleteSnapshot))
                    //            {
                    //                throw;
                    //            }
                    //        }

                    //        if (retryDeleteSnapshot)
                    //        {
                    //            if (force || await OutputStream.ConfirmAsync(string.Format("This share might have snapshots, remove the share and all snapshots?: {0}", share.Name)).ConfigureAwait(false))
                    //            {
                    //                deleteShareSnapshotsOption = DeleteShareSnapshotsOption.IncludeSnapshots;
                    //                await this.Channel.DeleteShareAsync(share, deleteShareSnapshotsOption, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    //            }
                    //            else
                    //            {
                    //                string result = string.Format("The remove operation of share '{0}' has been cancelled.", share.Name);
                    //                OutputStream.WriteVerbose(taskId, result);
                    //            }
                    //        }
                    //    }

                    //    if (this.PassThru)
                    //    {
                    //        WriteCloudShareObject(taskId, this.Channel, share);
                    //    }
                    //});
                }
            }
        }
    }
}
