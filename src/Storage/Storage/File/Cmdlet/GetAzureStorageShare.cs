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


namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using global::Azure.Storage.Files.Shares.Models;
    using global::Azure.Storage.Files.Shares;
    using global::Azure;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare", DefaultParameterSetName = Constants.MatchingPrefixParameterSetName)]
    [OutputType(typeof(AzureStorageFileShare))]
    public class GetAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.SpecificParameterSetName,
            HelpMessage = "Name of the file share to be received.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            ParameterSetName = Constants.MatchingPrefixParameterSetName,
            HelpMessage = "A prefix of the file shares to be listed.")]
        public string Prefix { get; set; }

        [Parameter(
        Position = 1,
        Mandatory = false,
        ParameterSetName = Constants.SpecificParameterSetName,
        HelpMessage = "SnapshotTime of the file share snapshot to be received.")]
                [ValidateNotNullOrEmpty]
                public DateTimeOffset? SnapshotTime { get; set; }

        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.MatchingPrefixParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.SpecificParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        public override IStorageContext Context { get; set; }

        public override void ExecuteCmdlet()
        {

            switch (this.ParameterSetName)
            {
                case Constants.SpecificParameterSetName:
                    NamingUtil.ValidateShareName(this.Name, false);

                    // TODO: handle snapshot
                    ShareClient share = Util.GetTrack2ShareReference(this.Name, 
                        Channel.StorageContext, 
                        this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToUniversalTime().ToString("u"),
                        ClientOptions);
                    ShareProperties shareProperties = share.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;
                    WriteObject(new AzureStorageFileShare(share, (AzureStorageContext)this.Context, shareProperties, ClientOptions));

                    break;

                case Constants.MatchingPrefixParameterSetName:
                    NamingUtil.ValidateShareName(this.Prefix, true);

                    ShareServiceClient shareService = Util.GetTrack2FileServiceClient(Channel.StorageContext, ClientOptions);
                    //TODO: ShareStates, add -IncludeDeleted
                    Pageable<ShareItem> shareitems = shareService.GetShares(ShareTraits.All, ShareStates.Snapshots, this.Prefix, this.CmdletCancellationToken);

                    foreach (ShareItem shareitem in shareitems)
                    {
                        ShareClient shareClient = shareService.GetShareClient(shareitem.Name);
                        WriteObject(new AzureStorageFileShare(shareClient, (AzureStorageContext)this.Context, shareitem, ClientOptions));
                    }

                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            //this.RunTask(async taskId =>
            //{

            //switch (this.ParameterSetName)
            //{
            //    case Constants.SpecificParameterSetName:
            //        NamingUtil.ValidateShareName(this.Name, false);
            //        var share = this.Channel.GetShareReference(this.Name, this.SnapshotTime);
            //        await this.Channel.FetchShareAttributesAsync(share, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
            //        WriteCloudShareObject(taskId, this.Channel, share);

            //        break;

            //    case Constants.MatchingPrefixParameterSetName:
            //        NamingUtil.ValidateShareName(this.Prefix, true);
            //        await this.Channel.EnumerateSharesAsync(
            //            this.Prefix,
            //            ShareListingDetails.All,
            //            item => WriteCloudShareObject(taskId, this.Channel, item),
            //            this.RequestOptions,
            //            this.OperationContext,
            //            this.CmdletCancellationToken).ConfigureAwait(false);

            //        break;

            //    default:
            //        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            //}
            //});
        }
    }
}
