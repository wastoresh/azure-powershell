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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// create a new azure FileSystem
    /// </summary>
    [Cmdlet("Update", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2AclRecursive", SupportsShouldProcess = true), OutputType(typeof(string))]
    public class UpdateAzDataLakeGen2AclRecursiveCommand : DataLakeGen2ACLRecursiveBaseCmdlet
    {
        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        public UpdateAzDataLakeGen2AclRecursiveCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public UpdateAzDataLakeGen2AclRecursiveCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            progressRecord = GetProgressRecord("Update");

            bool foundAFolder = false;

            DataLakeFileClient fileClient = null;
            DataLakeDirectoryClient dirClient = null;

            DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
            foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient);


            if (foundAFolder)
            {
                if (ShouldProcess(dirClient.Uri.ToString(), "Update Acl recursively on Directory: "))
                {
                        dirClient.UpdateAccessControlRecursive(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                                this.batchSize,
                                GetProgressHandler(),
                                this.StopOnFailure.IsPresent);
                }
            }
            else
            {
                if (ShouldProcess(fileClient.Uri.ToString(), "Update Acl recursively on File: "))
                {
                    fileClient.UpdateAccessControlRecursive(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                        this.batchSize,
                        GetProgressHandler(),
                        this.StopOnFailure.IsPresent);
                }
            }
            WriteResult();
        }
    }
}
