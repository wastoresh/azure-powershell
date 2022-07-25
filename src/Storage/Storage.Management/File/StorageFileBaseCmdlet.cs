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

using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
//using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Storage
{
    public abstract class StorageFileBaseCmdlet : AzureRMCmdlet
    {   
        protected const string AccountNameAlias = "AccountName";
        protected const string NameAlias = "Name";

        protected const string StorageShareNounStr = "StorageShare";
        protected const string StorageFileServiceProperty = "StorageFileServiceProperty";

        public const string StorageAccountResourceType = "Microsoft.Storage/storageAccounts";

        protected struct SmbProtocolVersions
        {
            internal const string SMB21 = "SMB2.1";
            internal const string SMB30 = "SMB3.0";
            internal const string SMB311 = "SMB3.1.1";
        }

        protected struct SmbAuthenticationMethods
        {
            internal const string NTLMv2 = "NTLMv2";
            internal const string Kerberos = "Kerberos";
        }

        protected struct ChannelEncryption
        {
            internal const string AES128CCM = "AES-128-CCM";
            internal const string AES128GCM = "AES-128-GCM"; 
            internal const string AES256GCM = "AES-256-GCM";
        }

        protected struct KerberosTicketEncryption
        {
            internal const string RC4HMAC = "RC4-HMAC";
            internal const string AES256 = "AES-256";
        }

        protected struct ShareListExpand
        {
            internal const string Deleted = "deleted";
            internal const string Snapshots = "snapshots";
        }

        protected struct ShareRemoveInclude
        {
            internal const string LeasedSnapshots = "Leased-Snapshots";
            internal const string Snapshots = "Snapshots";
            internal const string None = "None";
        }

        protected struct ShareGetExpand
        {
            internal const string Stats = "stats";
        }

        protected struct ShareCreateExpand
        {
            internal const string Snapshots = "snapshots";
        }

        protected struct RootSquashType
        {
            internal const string NoRootSquash = "NoRootSquash";
            internal const string RootSquash = "RootSquash";
            internal const string AllSquash = "AllSquash";
        }

        protected struct ShareAccessTier
        {
            internal const string TransactionOptimized = "TransactionOptimized";
            internal const string Hot = "Hot";
            internal const string Cool = "Cool";
            internal const string Premium = "Premium";
        }

        protected struct EncryptionScopeState
        {
            internal const string Enabled = "Enabled";
            internal const string Disabled = "Disabled";
        }

        protected struct EnabledProtocols
        {
            internal const string SMB = "SMB";
            internal const string NFS = "NFS";
        }

        public string ConnectStringArray(string[] stringArray, string seperator = ";")
        {
            if (stringArray == null)
            {
                return null;
            }
            string returnValue = string.Empty;

            foreach( string s in stringArray)
            {
                returnValue += s + seperator;
            }
            if (!String.IsNullOrEmpty(returnValue))
            {
                returnValue = returnValue.Substring(0, returnValue.Length - seperator.Length);
            }
            return returnValue;
        }

        private Track2StorageManagementClient _track2StorageManagementClient;
        public Track2StorageManagementClient StorageClientTrack2
        {
            get
            {
                return _track2StorageManagementClient ?? (_track2StorageManagementClient = new Track2StorageManagementClient(
                    Microsoft.Azure.Commands.Common.Authentication.AzureSession.Instance.ClientFactory,
                    DefaultContext));
            }

            set { _track2StorageManagementClient = value; }
        }

        public string SubscriptionId
        {
            get
            {
                return DefaultProfile.DefaultContext.Subscription.Id.ToString();
            }
        }

        public static Dictionary<string, string> CreateMetadataDictionary(Hashtable Metadata, bool validate)
        {
            Dictionary<string, string> MetadataDictionary = null;
            if (Metadata != null)
            {
                MetadataDictionary = new Dictionary<string, string>();

                string dirKey = null;
                string dirValue = null;
                foreach (DictionaryEntry entry in Metadata)
                {
                    dirKey = entry.Key.ToString();
                    if (entry.Value != null)
                    {
                        dirValue = entry.Value.ToString();
                    }
                    else
                    {
                        dirValue = string.Empty;
                    }
                    MetadataDictionary[dirKey] = dirValue;
                }
            }
            return MetadataDictionary;
        }
    }
}
