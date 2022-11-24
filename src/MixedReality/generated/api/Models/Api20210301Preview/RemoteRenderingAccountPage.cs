// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.Extensions;

    /// <summary>
    /// Result of the request to get resource collection. It contains a list of resources and a URL link to get the next set of
    /// results.
    /// </summary>
    public partial class RemoteRenderingAccountPage :
        Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccountPage,
        Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccountPageInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of resource list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Origin(Microsoft.Azure.PowerShell.Cmdlets.MixedReality.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount[] _value;

        /// <summary>List of resources supported by the Resource Provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Origin(Microsoft.Azure.PowerShell.Cmdlets.MixedReality.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="RemoteRenderingAccountPage" /> instance.</summary>
        public RemoteRenderingAccountPage()
        {

        }
    }
    /// Result of the request to get resource collection. It contains a list of resources and a URL link to get the next set of
    /// results.
    public partial interface IRemoteRenderingAccountPage :
        Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of resource list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of resource list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of resources supported by the Resource Provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of resources supported by the Resource Provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount[] Value { get; set; }

    }
    /// Result of the request to get resource collection. It contains a list of resources and a URL link to get the next set of
    /// results.
    internal partial interface IRemoteRenderingAccountPageInternal

    {
        /// <summary>URL to get the next set of resource list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of resources supported by the Resource Provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IRemoteRenderingAccount[] Value { get; set; }

    }
}