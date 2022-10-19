// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Extensions;

    /// <summary>The pricing tier of the solution</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ISkuInternal
    {

        /// <summary>Backing field for <see cref="CapacityReservationLevel" /> property.</summary>
        private int? _capacityReservationLevel;

        /// <summary>The amount of reservation level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public int? CapacityReservationLevel { get => this._capacityReservationLevel; set => this._capacityReservationLevel = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SkuKind? _name;

        /// <summary>The kind of the tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SkuKind? Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// The pricing tier of the solution
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.IJsonSerializable
    {
        /// <summary>The amount of reservation level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The amount of reservation level",
        SerializedName = @"capacityReservationLevel",
        PossibleTypes = new [] { typeof(int) })]
        int? CapacityReservationLevel { get; set; }
        /// <summary>The kind of the tier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The kind of the tier",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SkuKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SkuKind? Name { get; set; }

    }
    /// The pricing tier of the solution
    internal partial interface ISkuInternal

    {
        /// <summary>The amount of reservation level</summary>
        int? CapacityReservationLevel { get; set; }
        /// <summary>The kind of the tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SkuKind? Name { get; set; }

    }
}