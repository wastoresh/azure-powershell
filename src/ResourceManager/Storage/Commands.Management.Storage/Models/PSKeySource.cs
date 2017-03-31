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

using Microsoft.Azure.Management.Storage.Models;
using System.ComponentModel;

namespace Microsoft.Azure.Commands.Management.Storage.Models
{

    public struct PsKeyvaultproperties
    {
        public string Keyname;

        public string Keyvaulturi;

        public string Keyversion;
    }


    public enum PsKeySourceTypeEnum
    {
        MicrosoftStorage,
        MicrosoftKeyVault
    }

    public struct PSKeySource
    {

        // Summary:
        //     Gets or sets the encryption keySource (provider). Possible values (case-insensitive):
        //     Microsoft.Storage, Microsoft.KeyVault. Possible values include: 'Microsoft.Storage',
        //     'Microsoft.KeyVault'
        public PsKeySourceTypeEnum KeySource;
        
        // Summary:
        //     Gets or sets properties provided by key vault.
        public PsKeyvaultproperties Keyvaultproperties;
    }
}
