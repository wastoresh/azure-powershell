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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Adapters;
using Microsoft.Azure.Storage;
using System;
using System.Collections.Generic;
using Track2 = Azure.ResourceManager.Storage;
using Track2Models = Azure.ResourceManager.Storage.Models;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{
    // wrapper of EncryptionScope
    public class PSEncryptionScope
    {
        public PSEncryptionScope(Track2.EncryptionScopeResource scope)
        {
            this.ResourceGroupName = ParseResourceGroupFromId(scope.Id);
            this.StorageAccountName = ParseStorageAccountNameFromId(scope.Id);
            this.Id = scope.Id;
            this.Name = scope.Data.Name;
            this.Type = scope.Data.ResourceType;
            this.LastModifiedTime = scope.Data.LastModifiedOn;
            this.CreationTime = scope.Data.CreationOn;
            this.Source = scope.Data.Source.ToString();
            this.State = scope.Data.State.ToString();
            this.KeyVaultProperties = scope.Data.KeyVaultProperties is null ? null : new PSEncryptionScopeKeyVaultProperties(scope.Data.KeyVaultProperties);
            this.RequireInfrastructureEncryption = scope.Data.RequireInfrastructureEncryption;
        }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "StorageAccountName", Target = ViewControl.List, Position = 1)]
        public string StorageAccountName { get; set; }

        public string Id { get; set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 2)]
        public string Name { get; set; }

        public string Type { get; set; }

        public string Source { get; set; }

        public string State { get; set; }

        public PSEncryptionScopeKeyVaultProperties KeyVaultProperties { get; set; }

        public bool? RequireInfrastructureEncryption { get; set; }

        [Ps1Xml(Label = "LastModifiedTime", Target = ViewControl.List, Position = 4)]
        public DateTimeOffset? LastModifiedTime { get; set; }

        public DateTimeOffset? CreationTime { get; set; }

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

    }

    //wrapper of EncryptionScopeKeyVaultProperties
    public class PSEncryptionScopeKeyVaultProperties
    {
        public PSEncryptionScopeKeyVaultProperties(Track2Models.EncryptionScopeKeyVaultProperties keyVaultProperties)
        {
            if (keyVaultProperties != null)
            {
                if (keyVaultProperties.KeyUri != null)
                {
                    this.keyUri = keyVaultProperties.KeyUri.OriginalString;
                }
            }
        }

        public string keyUri { get; set; }
    }

  
}
