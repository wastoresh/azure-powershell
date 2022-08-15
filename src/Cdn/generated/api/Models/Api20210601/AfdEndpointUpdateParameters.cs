// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    /// <summary>Properties required to create or update an endpoint.</summary>
    public partial class AfdEndpointUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersInternal
    {

        /// <summary>
        /// Whether to enable use of this rule. Permitted values are 'Enabled' or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState? EnabledState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)Property).EnabledState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)Property).EnabledState = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState)""); }

        /// <summary>Internal Acessors for ProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersInternal.ProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)Property).ProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)Property).ProfileName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParameters Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointPropertiesUpdateParameters()); set { {_property = value;} } }

        /// <summary>The name of the profile which holds the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public string ProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParametersInternal)Property).ProfileName; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParameters _property;

        /// <summary>The JSON object containing endpoint update parameters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointPropertiesUpdateParameters()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersTags _tag;

        /// <summary>Endpoint tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.AfdEndpointUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="AfdEndpointUpdateParameters" /> instance.</summary>
        public AfdEndpointUpdateParameters()
        {

        }
    }
    /// Properties required to create or update an endpoint.
    public partial interface IAfdEndpointUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Whether to enable use of this rule. Permitted values are 'Enabled' or 'Disabled'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable use of this rule. Permitted values are 'Enabled' or 'Disabled'",
        SerializedName = @"enabledState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState? EnabledState { get; set; }
        /// <summary>The name of the profile which holds the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the profile which holds the endpoint.",
        SerializedName = @"profileName",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileName { get;  }
        /// <summary>Endpoint tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Endpoint tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersTags Tag { get; set; }

    }
    /// Properties required to create or update an endpoint.
    internal partial interface IAfdEndpointUpdateParametersInternal

    {
        /// <summary>
        /// Whether to enable use of this rule. Permitted values are 'Enabled' or 'Disabled'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.EnabledState? EnabledState { get; set; }
        /// <summary>The name of the profile which holds the endpoint.</summary>
        string ProfileName { get; set; }
        /// <summary>The JSON object containing endpoint update parameters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointPropertiesUpdateParameters Property { get; set; }
        /// <summary>Endpoint tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IAfdEndpointUpdateParametersTags Tag { get; set; }

    }
}