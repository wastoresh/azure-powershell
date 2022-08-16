// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>
    /// Tags of the service which is a list of key value pairs that describe the resource.
    /// </summary>
    public partial class TrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ITrackedResourceTags,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ITrackedResourceTagsInternal
    {

        /// <summary>Creates an new <see cref="TrackedResourceTags" /> instance.</summary>
        public TrackedResourceTags()
        {

        }
    }
    /// Tags of the service which is a list of key value pairs that describe the resource.
    public partial interface ITrackedResourceTags :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IAssociativeArray<string>
    {

    }
    /// Tags of the service which is a list of key value pairs that describe the resource.
    internal partial interface ITrackedResourceTagsInternal

    {

    }
}