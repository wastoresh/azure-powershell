// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.Extensions;

    /// <summary>Properties to configure Identity for Bring your Own Keys</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.EventHub.DoNotFormat]
    public partial class Identity :
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityInternal
    {

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Internal Acessors for TenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityInternal.TenantId { get => this._tenantId; set { {_tenantId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>ObjectId from the KeyVault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventHub.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>TenantId from the KeyVault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventHub.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType? _type;

        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UserAssignedIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityUserAssignedIdentities _userAssignedIdentity;

        /// <summary>Properties for User Assigned Identities</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.EventHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityUserAssignedIdentities UserAssignedIdentity { get => (this._userAssignedIdentity = this._userAssignedIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IdentityUserAssignedIdentities()); set => this._userAssignedIdentity = value; }

        /// <summary>Creates an new <see cref="Identity" /> instance.</summary>
        public Identity()
        {

        }
    }
    /// Properties to configure Identity for Bring your Own Keys
    public partial interface IIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.IJsonSerializable
    {
        /// <summary>ObjectId from the KeyVault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ObjectId from the KeyVault",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }
        /// <summary>TenantId from the KeyVault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"TenantId from the KeyVault",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get;  }
        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of managed service identity.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType? Type { get; set; }
        /// <summary>Properties for User Assigned Identities</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EventHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Properties for User Assigned Identities",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
    /// Properties to configure Identity for Bring your Own Keys
    internal partial interface IIdentityInternal

    {
        /// <summary>ObjectId from the KeyVault</summary>
        string PrincipalId { get; set; }
        /// <summary>TenantId from the KeyVault</summary>
        string TenantId { get; set; }
        /// <summary>Type of managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.ManagedServiceIdentityType? Type { get; set; }
        /// <summary>Properties for User Assigned Identities</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IIdentityUserAssignedIdentities UserAssignedIdentity { get; set; }

    }
}