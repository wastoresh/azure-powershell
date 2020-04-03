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
    using Microsoft.Azure.Storage.Blob;
    using System;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Microsoft.Azure.Storage.File;

    /// <summary>
    /// Azure storage file object
    /// </summary>
    public class AzureStorageFile : AzureStorageBase
    {
        /// <summary>
        /// CloudBlob object
        /// </summary>    
        [Ps1Xml(Label = "Share Uri", Target = ViewControl.Table, GroupByThis = true, ScriptBlock = "$_.CloudFile.Share.Uri")]
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, ScriptBlock = "$_.Name", Position = 0, TableColumnWidth = 20)]
        public CloudFile CloudFile { get; private set; }

        /// <summary>
        /// Blob length
        /// </summary>
        [Ps1Xml(Label = "Length", Target = ViewControl.Table, Position = 1, TableColumnWidth = 15)]
        public long Length { get; private set; }
        
        /// <summary>
        /// file last modified time
        /// </summary>
        [Ps1Xml(Label = "LastModified", Target = ViewControl.Table, ScriptBlock = "$_.LastModified.UtcDateTime.ToString(\"u\")", Position = 2, TableColumnWidth = 20)]
        public DateTimeOffset? LastModified { get; private set; }

        ///// <summary>
        ///// Blob continuation token
        ///// </summary>
        //public BlobContinuationToken ContinuationToken { get; set; }

        /// <summary>
        /// Azure storage file constructor
        /// </summary>
        /// <param name="file">Cloud file object</param>
        public AzureStorageFile(CloudFile file)
        {
            Name = file.Name;
            CloudFile = file;
            Length = file.Properties.Length;
            LastModified = file.Properties.LastModified;
        }
    }
}
