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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlUserDefinedFunction", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlUserDefinedFunctionGetResults))]
    public class SetAzCosmosDBSqlUserDefinedFunction : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ContainerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.UserDefinedFunctionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.UserDefinedFunctionBodyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Body { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.SqlContainerObjectHelpMessage)]
        [ValidateNotNull]
        public PSSqlContainerGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                ContainerName = resourceIdentifier.ResourceName;
                DatabaseName = ResourceIdentifierExtensions.GetSqlDatabaseName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            SqlUserDefinedFunctionCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters
            {
                Resource = new SqlUserDefinedFunctionResource
                {
                    Id = Name,
                    Body = Body
                },
                Options = new CreateUpdateOptions() { }
            };

            if (ShouldProcess(Name, "Setting CosmosDB Sql User Defined Function"))
            {
                SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = CosmosDBManagementClient.SqlResources.CreateUpdateSqlUserDefinedFunctionWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, ContainerName, Name, sqlStoredProcedureCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSSqlUserDefinedFunctionGetResults(sqlUserDefinedFunctionGetResults));
            }

            return;
        }
    }
}
