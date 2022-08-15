// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Extensions;

    /// <summary>AuthConfig collection ARM resource.</summary>
    public partial class AuthConfigCollection :
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfigCollection,
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfigCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfigCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Origin(Microsoft.Azure.PowerShell.Cmdlets.App.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AuthConfigCollection" /> instance.</summary>
        public AuthConfigCollection()
        {

        }
    }
    /// AuthConfig collection ARM resource.
    public partial interface IAuthConfigCollection :
        Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.IJsonSerializable
    {
        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.App.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Collection of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig) })]
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig[] Value { get; set; }

    }
    /// AuthConfig collection ARM resource.
    internal partial interface IAuthConfigCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IAuthConfig[] Value { get; set; }

    }
}