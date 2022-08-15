// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    public partial class SplitRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitRequestInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitProperties Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.SplitProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.SplitProperties()); set => this._property = value; }

        /// <summary>List of the quantities in the new reservations to create.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public int[] Quantity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitPropertiesInternal)Property).Quantity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitPropertiesInternal)Property).Quantity = value ?? null /* arrayOf */; }

        /// <summary>
        /// Resource id of the reservation to be split. Format of the resource id should be /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        public string ReservationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitPropertiesInternal)Property).ReservationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitPropertiesInternal)Property).ReservationId = value ?? null; }

        /// <summary>Creates an new <see cref="SplitRequest" /> instance.</summary>
        public SplitRequest()
        {

        }
    }
    public partial interface ISplitRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>List of the quantities in the new reservations to create.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of the quantities in the new reservations to create.",
        SerializedName = @"quantities",
        PossibleTypes = new [] { typeof(int) })]
        int[] Quantity { get; set; }
        /// <summary>
        /// Resource id of the reservation to be split. Format of the resource id should be /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of the reservation to be split. Format of the resource id should be /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}",
        SerializedName = @"reservationId",
        PossibleTypes = new [] { typeof(string) })]
        string ReservationId { get; set; }

    }
    internal partial interface ISplitRequestInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ISplitProperties Property { get; set; }
        /// <summary>List of the quantities in the new reservations to create.</summary>
        int[] Quantity { get; set; }
        /// <summary>
        /// Resource id of the reservation to be split. Format of the resource id should be /providers/Microsoft.Capacity/reservationOrders/{reservationOrderId}/reservations/{reservationId}
        /// </summary>
        string ReservationId { get; set; }

    }
}