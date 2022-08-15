// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Extensions;

    /// <summary>CalculateExchange operation result</summary>
    public partial class CalculateExchangeOperationResultResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal
    {

        /// <summary>
        /// Required if status == failed or status == cancelled. If status == failed, provide an invariant error code used for error
        /// troubleshooting, aggregation, and analysis.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultErrorInternal)Error).Code = value ?? null; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError _error;

        /// <summary>Required if status == failed or status == canceled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.OperationResultError()); set => this._error = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>It should match what is used to GET the operation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Required if status == failed. Localized. If status == failed, provide an actionable error message indicating what error
        /// occurred, and what the user can do to address the issue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultErrorInternal)Error).Message = value ?? null; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.OperationResultError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for PolicyResult</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyErrors Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal.PolicyResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PolicyResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PolicyResult = value; }

        /// <summary>Internal Acessors for Properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeOperationResultResponseInternal.Properties { get => (this._properties = this._properties ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeResponseProperties()); set { {_properties = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// It must match the last segment of the id field, and will typically be a GUID / system generated value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string Name { get => this._name; set => this._name = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice NetPayable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).NetPayable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).NetPayable = value ?? null /* model class */; }

        /// <summary>Exchange Policy errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError[] PolicyResultPolicyError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PolicyResultPolicyError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PolicyResultPolicyError = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Properties" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties _properties;

        /// <summary>CalculateExchange response properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties Properties { get => (this._properties = this._properties ?? new Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.CalculateExchangeResponseProperties()); set => this._properties = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PurchasesTotal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PurchasesTotal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).PurchasesTotal = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice RefundsTotal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).RefundsTotal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).RefundsTotal = value ?? null /* model class */; }

        /// <summary>Details of the reservations being returned</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange[] ReservationsToExchange { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).ReservationsToExchange; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).ReservationsToExchange = value ?? null /* arrayOf */; }

        /// <summary>Details of the reservations being purchased</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange[] ReservationsToPurchase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).ReservationsToPurchase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).ReservationsToPurchase = value ?? null /* arrayOf */; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.DoNotFormat]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>Exchange session identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 0)]
        public string SessionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).SessionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponsePropertiesInternal)Properties).SessionId = value ?? null; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus? _status;

        /// <summary>Status of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Origin(Microsoft.Azure.PowerShell.Cmdlets.Reservations.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.FormatTable(Index = 1)]
        public Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus? Status { get => this._status; set => this._status = value; }

        /// <summary>
        /// Creates an new <see cref="CalculateExchangeOperationResultResponse" /> instance.
        /// </summary>
        public CalculateExchangeOperationResultResponse()
        {

        }
    }
    /// CalculateExchange operation result
    public partial interface ICalculateExchangeOperationResultResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Required if status == failed or status == cancelled. If status == failed, provide an invariant error code used for error
        /// troubleshooting, aggregation, and analysis.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required if status == failed or status == cancelled. If status == failed, provide an invariant error code used for error troubleshooting, aggregation, and analysis.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>It should match what is used to GET the operation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It should match what is used to GET the operation result.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>
        /// Required if status == failed. Localized. If status == failed, provide an actionable error message indicating what error
        /// occurred, and what the user can do to address the issue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Required if status == failed. Localized. If status == failed, provide an actionable error message indicating what error occurred, and what the user can do to address the issue.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// It must match the last segment of the id field, and will typically be a GUID / system generated value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"It must match the last segment of the id field, and will typically be a GUID / system generated value.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"netPayable",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice NetPayable { get; set; }
        /// <summary>Exchange Policy errors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Exchange Policy errors",
        SerializedName = @"policyErrors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError[] PolicyResultPolicyError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"purchasesTotal",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PurchasesTotal { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"refundsTotal",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice RefundsTotal { get; set; }
        /// <summary>Details of the reservations being returned</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Details of the reservations being returned",
        SerializedName = @"reservationsToExchange",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange[] ReservationsToExchange { get; set; }
        /// <summary>Details of the reservations being purchased</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Details of the reservations being purchased",
        SerializedName = @"reservationsToPurchase",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange[] ReservationsToPurchase { get; set; }
        /// <summary>Exchange session identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Exchange session identifier",
        SerializedName = @"sessionId",
        PossibleTypes = new [] { typeof(string) })]
        string SessionId { get; set; }
        /// <summary>Status of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of the operation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus? Status { get; set; }

    }
    /// CalculateExchange operation result
    internal partial interface ICalculateExchangeOperationResultResponseInternal

    {
        /// <summary>
        /// Required if status == failed or status == cancelled. If status == failed, provide an invariant error code used for error
        /// troubleshooting, aggregation, and analysis.
        /// </summary>
        string Code { get; set; }
        /// <summary>Required if status == failed or status == canceled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IOperationResultError Error { get; set; }
        /// <summary>It should match what is used to GET the operation result.</summary>
        string Id { get; set; }
        /// <summary>
        /// Required if status == failed. Localized. If status == failed, provide an actionable error message indicating what error
        /// occurred, and what the user can do to address the issue.
        /// </summary>
        string Message { get; set; }
        /// <summary>
        /// It must match the last segment of the id field, and will typically be a GUID / system generated value.
        /// </summary>
        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice NetPayable { get; set; }
        /// <summary>Exchange policy errors</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyErrors PolicyResult { get; set; }
        /// <summary>Exchange Policy errors</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IExchangePolicyError[] PolicyResultPolicyError { get; set; }
        /// <summary>CalculateExchange response properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.ICalculateExchangeResponseProperties Properties { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice PurchasesTotal { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice RefundsTotal { get; set; }
        /// <summary>Details of the reservations being returned</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToExchange[] ReservationsToExchange { get; set; }
        /// <summary>Details of the reservations being purchased</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IReservationToPurchaseCalculateExchange[] ReservationsToPurchase { get; set; }
        /// <summary>Exchange session identifier</summary>
        string SessionId { get; set; }
        /// <summary>Status of the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.CalculateExchangeOperationResultStatus? Status { get; set; }

    }
}