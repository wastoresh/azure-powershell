// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Properties that define a Azure Arc PrivateLinkScope resource.</summary>
    public partial class HybridComputePrivateLinkScopeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IHybridComputePrivateLinkScopeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IHybridComputePrivateLinkScopePropertiesInternal
    {

        /// <summary>Internal Acessors for PrivateEndpointConnection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IHybridComputePrivateLinkScopePropertiesInternal.PrivateEndpointConnection { get => this._privateEndpointConnection; set { {_privateEndpointConnection = value;} } }

        /// <summary>Internal Acessors for PrivateLinkScopeId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IHybridComputePrivateLinkScopePropertiesInternal.PrivateLinkScopeId { get => this._privateLinkScopeId; set { {_privateLinkScopeId = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IHybridComputePrivateLinkScopePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="PrivateEndpointConnection" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel[] _privateEndpointConnection;

        /// <summary>The collection of associated Private Endpoint Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel[] PrivateEndpointConnection { get => this._privateEndpointConnection; }

        /// <summary>Backing field for <see cref="PrivateLinkScopeId" /> property.</summary>
        private string _privateLinkScopeId;

        /// <summary>The Guid id of the private link scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string PrivateLinkScopeId { get => this._privateLinkScopeId; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Current state of this PrivateLinkScope: whether or not is has been provisioned within the resource group it is defined.
        /// Users cannot change this value but are able to read from it. Values will include Provisioning ,Succeeded, Canceled and
        /// Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="PublicNetworkAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PublicNetworkAccessType? _publicNetworkAccess;

        /// <summary>
        /// Indicates whether machines associated with the private link scope can also use public Azure Arc service endpoints.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PublicNetworkAccessType? PublicNetworkAccess { get => this._publicNetworkAccess; set => this._publicNetworkAccess = value; }

        /// <summary>Creates an new <see cref="HybridComputePrivateLinkScopeProperties" /> instance.</summary>
        public HybridComputePrivateLinkScopeProperties()
        {

        }
    }
    /// Properties that define a Azure Arc PrivateLinkScope resource.
    public partial interface IHybridComputePrivateLinkScopeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The collection of associated Private Endpoint Connections.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The collection of associated Private Endpoint Connections.",
        SerializedName = @"privateEndpointConnections",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel[] PrivateEndpointConnection { get;  }
        /// <summary>The Guid id of the private link scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Guid id of the private link scope.",
        SerializedName = @"privateLinkScopeId",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkScopeId { get;  }
        /// <summary>
        /// Current state of this PrivateLinkScope: whether or not is has been provisioned within the resource group it is defined.
        /// Users cannot change this value but are able to read from it. Values will include Provisioning ,Succeeded, Canceled and
        /// Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current state of this PrivateLinkScope: whether or not is has been provisioned within the resource group it is defined. Users cannot change this value but are able to read from it. Values will include Provisioning ,Succeeded, Canceled and Failed.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Indicates whether machines associated with the private link scope can also use public Azure Arc service endpoints.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether machines associated with the private link scope can also use public Azure Arc service endpoints.",
        SerializedName = @"publicNetworkAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PublicNetworkAccessType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PublicNetworkAccessType? PublicNetworkAccess { get; set; }

    }
    /// Properties that define a Azure Arc PrivateLinkScope resource.
    internal partial interface IHybridComputePrivateLinkScopePropertiesInternal

    {
        /// <summary>The collection of associated Private Endpoint Connections.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IPrivateEndpointConnectionDataModel[] PrivateEndpointConnection { get; set; }
        /// <summary>The Guid id of the private link scope.</summary>
        string PrivateLinkScopeId { get; set; }
        /// <summary>
        /// Current state of this PrivateLinkScope: whether or not is has been provisioned within the resource group it is defined.
        /// Users cannot change this value but are able to read from it. Values will include Provisioning ,Succeeded, Canceled and
        /// Failed.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Indicates whether machines associated with the private link scope can also use public Azure Arc service endpoints.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PublicNetworkAccessType? PublicNetworkAccess { get; set; }

    }
}