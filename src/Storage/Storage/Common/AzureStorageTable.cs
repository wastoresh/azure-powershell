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
// ---------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using global::Azure.Data.Tables;
    using Microsoft.WindowsAzure.Commands.Storage;

    /// <summary>
    /// Azure storage table object
    /// </summary>
    public class AzureStorageTable : AzureStorageBase
    {
        /// <summary>
        /// Cloud table object
        /// </summary>
        [Ps1Xml(Label = "Table End Point", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudTable.ServiceClient.BaseUri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0)]
        public CloudTable CloudTable { get; private set; }


        public TableClient TableClient { get; private set; }

        /// <summary>
        /// Table uri
        /// </summary>
        [Ps1Xml(Label = "Uri", Target = ViewControl.Table, ScriptBlock = "$_.Uri", Position = 1)]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Azure storage table constructor
        /// </summary>
        /// <param name="table">Cloud table object</param>
        //public AzureStorageTable(CloudTable table)
        //{
        //    Name = table.Name;
        //    CloudTable = table;
        //    Uri = table.Uri;
        //}

        public AzureStorageTable(TableClient table, AzureStorageContext context)
        {
            Name = table.Name;
            TableClient = table;
            if (!context.StorageAccount.Credentials.IsToken) // only output Track1 object when not oauth, since Ttrack1 SDK don't support Oauth
            {
                CloudTable = context.TableStorageAccount.CreateCloudTableClient().GetTableReference(table.Name);
            }
            // TODO: Track2 SDK missing Uri properties, need update it when Track2 SDK support Uri.
            //Uri = table.Uri;
        }
    }
}
