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

using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using System.Collections.Generic;
using Track2 = Azure.ResourceManager.Storage;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    public class PSShare //: CloudFileShare
    {
        public PSShare(Track2.FileShareResource share)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(share.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(share.Id);
            this.Id = share.Id;
            this.Name = share.Data.Name;
            this.Type = share.Data.ResourceType;
            this.Metadata = share.Data.Metadata;
            this.Etag = share.Data.ETag?.ToString();
            this.LastModifiedTime = share.Data.LastModifiedOn;
            this.QuotaGiB = share.Data.ShareQuota;
            if (share.Data.EnabledProtocol != null)
            {
                this.EnabledProtocols = share.Data.EnabledProtocol.ToString();
            }
            if (share.Data.RootSquash != null)
            {
                this.RootSquash = share.Data.RootSquash.ToString();
            }
            this.Version = share.Data.Version;
            this.Deleted = share.Data.IsDeleted;
            this.DeletedTime = share.Data.DeletedOn;
            this.RemainingRetentionDays = share.Data.RemainingRetentionDays;
            this.ShareUsageBytes = share.Data.ShareUsageBytes;
            if (share.Data.AccessTier != null)
            {
                this.AccessTier = share.Data.AccessTier.ToString();
            }
            this.AccessTierChangeTime = share.Data.AccessTierChangeOn;
            this.AccessTierStatus = share.Data.AccessTierStatus;
            this.SnapshotTime = share.Data.SnapshotOn;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.Table, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Etag { get; set; }

        [Ps1Xml(Label = "QuotaGiB", Target = ViewControl.Table, Position = 3)]
        public int? QuotaGiB { get; set; }

        public IDictionary<string, string> Metadata { get; set; }       

        public DateTimeOffset? LastModifiedTime { get; set; }

        [Ps1Xml(Label = "Version", Target = ViewControl.List, Position = 7)]
        public string Version { get; set; }

        public bool? Deleted { get; private set; }

        [Ps1Xml(Label = "DeletedTime", Target = ViewControl.List, ScriptBlock = "$_.DeletedTime.ToString(\"u\")", Position = 6)]
        public DateTimeOffset? DeletedTime { get; private set; }

        public int? RemainingRetentionDays { get; private set; }

        public string EnabledProtocols { get; set; }
        public string RootSquash { get; set; }

        public string AccessTier { get; set; }
        public DateTimeOffset? AccessTierChangeTime { get; }
        public string AccessTierStatus { get; }

        public long? ShareUsageBytes { get; }

        public DateTimeOffset? SnapshotTime { get; private set; }
        public static string ParseResourceGroupFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[3];
            }

            return null;
        }

        public static string ParseStorageAccountNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[7];
            }

            return null;
        }

        public static string ParseStorageContainerNameFromId(string idFromServer)
        {
            if (!string.IsNullOrEmpty(idFromServer))
            {
                string[] tokens = idFromServer.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return tokens[11];
            }

            return null;
        }

        /// <summary>
        /// Return a string representation of this storage account
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            // Allow listing storage contents through piping
            return null;
        }
    }   
}
