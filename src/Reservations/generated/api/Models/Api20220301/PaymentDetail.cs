// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>Information about payment related to a reservation order.</summary>
    public partial class PaymentDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPaymentDetail,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPaymentDetailInternal
    {

        /// <summary>Backing field for <see cref="BillingAccount" /> property.</summary>
        private string _billingAccount;

        /// <summary>Shows the Account that is charged for this payment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string BillingAccount { get => this._billingAccount; set => this._billingAccount = value; }

        /// <summary>Backing field for <see cref="BillingCurrencyTotal" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice _billingCurrencyTotal;

        /// <summary>
        /// Amount charged in Billing currency. Tax not included. Is null for future payments
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice BillingCurrencyTotal { get => (this._billingCurrencyTotal = this._billingCurrencyTotal ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.Price()); set => this._billingCurrencyTotal = value; }

        /// <summary>Backing field for <see cref="DueDate" /> property.</summary>
        private global::System.DateTime? _dueDate;

        /// <summary>Date when the payment needs to be done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 0)]
        public global::System.DateTime? DueDate { get => this._dueDate; set => this._dueDate = value; }

        /// <summary>Backing field for <see cref="ExtendedStatusInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExtendedStatusInfo _extendedStatusInfo;

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExtendedStatusInfo ExtendedStatusInfo { get => (this._extendedStatusInfo = this._extendedStatusInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ExtendedStatusInfo()); set => this._extendedStatusInfo = value; }

        /// <summary>Backing field for <see cref="PaymentDate" /> property.</summary>
        private global::System.DateTime? _paymentDate;

        /// <summary>Date when the transaction is completed. Is null when it is scheduled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 1)]
        public global::System.DateTime? PaymentDate { get => this._paymentDate; set => this._paymentDate = value; }

        /// <summary>Backing field for <see cref="PricingCurrencyTotal" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice _pricingCurrencyTotal;

        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PricingCurrencyTotal { get => (this._pricingCurrencyTotal = this._pricingCurrencyTotal ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.Price()); set => this._pricingCurrencyTotal = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.PaymentStatus? _status;

        /// <summary>
        /// Describes whether the payment is completed, failed, cancelled or scheduled in the future.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 2)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.PaymentStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="PaymentDetail" /> instance.</summary>
        public PaymentDetail()
        {

        }
    }
    /// Information about payment related to a reservation order.
    public partial interface IPaymentDetail :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>Shows the Account that is charged for this payment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Shows the Account that is charged for this payment.",
        SerializedName = @"billingAccount",
        PossibleTypes = new [] { typeof(string) })]
        string BillingAccount { get; set; }
        /// <summary>
        /// Amount charged in Billing currency. Tax not included. Is null for future payments
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Amount charged in Billing currency. Tax not included. Is null for future payments",
        SerializedName = @"billingCurrencyTotal",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice BillingCurrencyTotal { get; set; }
        /// <summary>Date when the payment needs to be done.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date when the payment needs to be done.",
        SerializedName = @"dueDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DueDate { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"extendedStatusInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExtendedStatusInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExtendedStatusInfo ExtendedStatusInfo { get; set; }
        /// <summary>Date when the transaction is completed. Is null when it is scheduled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Date when the transaction is completed. Is null when it is scheduled.",
        SerializedName = @"paymentDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? PaymentDate { get; set; }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Amount in pricing currency. Tax not included.",
        SerializedName = @"pricingCurrencyTotal",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PricingCurrencyTotal { get; set; }
        /// <summary>
        /// Describes whether the payment is completed, failed, cancelled or scheduled in the future.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes whether the payment is completed, failed, cancelled or scheduled in the future.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.PaymentStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.PaymentStatus? Status { get; set; }

    }
    /// Information about payment related to a reservation order.
    internal partial interface IPaymentDetailInternal

    {
        /// <summary>Shows the Account that is charged for this payment.</summary>
        string BillingAccount { get; set; }
        /// <summary>
        /// Amount charged in Billing currency. Tax not included. Is null for future payments
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice BillingCurrencyTotal { get; set; }
        /// <summary>Date when the payment needs to be done.</summary>
        global::System.DateTime? DueDate { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExtendedStatusInfo ExtendedStatusInfo { get; set; }
        /// <summary>Date when the transaction is completed. Is null when it is scheduled.</summary>
        global::System.DateTime? PaymentDate { get; set; }
        /// <summary>Amount in pricing currency. Tax not included.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PricingCurrencyTotal { get; set; }
        /// <summary>
        /// Describes whether the payment is completed, failed, cancelled or scheduled in the future.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.PaymentStatus? Status { get; set; }

    }
}