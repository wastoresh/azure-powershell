// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support
{

    /// <summary>Argument completer implementation for ErrorResponseCode.</summary>
    [System.ComponentModel.TypeConverter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCodeTypeConverter))]
    public partial struct ErrorResponseCode :
        System.Management.Automation.IArgumentCompleter
    {

        /// <summary>
        /// Implementations of this function are called by PowerShell to complete arguments.
        /// </summary>
        /// <param name="commandName">The name of the command that needs argument completion.</param>
        /// <param name="parameterName">The name of the parameter that needs argument completion.</param>
        /// <param name="wordToComplete">The (possibly empty) word being completed.</param>
        /// <param name="commandAst">The command ast in case it is needed for completion.</param>
        /// <param name="fakeBoundParameters">This parameter is similar to $PSBoundParameters, except that sometimes PowerShell cannot
        /// or will not attempt to evaluate an argument, in which case you may need to use commandAst.</param>
        /// <returns>
        /// A collection of completion results, most like with ResultType set to ParameterValue.
        /// </returns>
        public global::System.Collections.Generic.IEnumerable<global::System.Management.Automation.CompletionResult> CompleteArgument(global::System.String commandName, global::System.String parameterName, global::System.String wordToComplete, global::System.Management.Automation.Language.CommandAst commandAst, global::System.Collections.IDictionary fakeBoundParameters)
        {
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NotSpecified".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'NotSpecified'", "NotSpecified", global::System.Management.Automation.CompletionResultType.ParameterValue, "NotSpecified");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InternalServerError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InternalServerError'", "InternalServerError", global::System.Management.Automation.CompletionResultType.ParameterValue, "InternalServerError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ServerTimeout".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ServerTimeout'", "ServerTimeout", global::System.Management.Automation.CompletionResultType.ParameterValue, "ServerTimeout");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AuthorizationFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'AuthorizationFailed'", "AuthorizationFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "AuthorizationFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BadRequest".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BadRequest'", "BadRequest", global::System.Management.Automation.CompletionResultType.ParameterValue, "BadRequest");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ClientCertificateThumbprintNotSet".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ClientCertificateThumbprintNotSet'", "ClientCertificateThumbprintNotSet", global::System.Management.Automation.CompletionResultType.ParameterValue, "ClientCertificateThumbprintNotSet");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidRequestContent".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidRequestContent'", "InvalidRequestContent", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidRequestContent");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "OperationFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'OperationFailed'", "OperationFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "OperationFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "HttpMethodNotSupported".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'HttpMethodNotSupported'", "HttpMethodNotSupported", global::System.Management.Automation.CompletionResultType.ParameterValue, "HttpMethodNotSupported");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidRequestUri".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidRequestUri'", "InvalidRequestUri", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidRequestUri");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "MissingTenantId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'MissingTenantId'", "MissingTenantId", global::System.Management.Automation.CompletionResultType.ParameterValue, "MissingTenantId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidTenantId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidTenantId'", "InvalidTenantId", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidTenantId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidReservationOrderId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidReservationOrderId'", "InvalidReservationOrderId", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidReservationOrderId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidReservationId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidReservationId'", "InvalidReservationId", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidReservationId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReservationIdNotInReservationOrder".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReservationIdNotInReservationOrder'", "ReservationIdNotInReservationOrder", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReservationIdNotInReservationOrder");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReservationOrderNotFound".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReservationOrderNotFound'", "ReservationOrderNotFound", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReservationOrderNotFound");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidSubscriptionId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidSubscriptionId'", "InvalidSubscriptionId", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidSubscriptionId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidAccessToken".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidAccessToken'", "InvalidAccessToken", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidAccessToken");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidLocationId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidLocationId'", "InvalidLocationId", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidLocationId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UnauthenticatedRequestsThrottled".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'UnauthenticatedRequestsThrottled'", "UnauthenticatedRequestsThrottled", global::System.Management.Automation.CompletionResultType.ParameterValue, "UnauthenticatedRequestsThrottled");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidHealthCheckType".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidHealthCheckType'", "InvalidHealthCheckType", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidHealthCheckType");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "Forbidden".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'Forbidden'", "Forbidden", global::System.Management.Automation.CompletionResultType.ParameterValue, "Forbidden");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingScopeIdCannotBeChanged".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingScopeIdCannotBeChanged'", "BillingScopeIdCannotBeChanged", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingScopeIdCannotBeChanged");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AppliedScopesNotAssociatedWithCommerceAccount".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'AppliedScopesNotAssociatedWithCommerceAccount'", "AppliedScopesNotAssociatedWithCommerceAccount", global::System.Management.Automation.CompletionResultType.ParameterValue, "AppliedScopesNotAssociatedWithCommerceAccount");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PatchValuesSameAsExisting".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'PatchValuesSameAsExisting'", "PatchValuesSameAsExisting", global::System.Management.Automation.CompletionResultType.ParameterValue, "PatchValuesSameAsExisting");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RoleAssignmentCreationFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'RoleAssignmentCreationFailed'", "RoleAssignmentCreationFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "RoleAssignmentCreationFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReservationOrderCreationFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReservationOrderCreationFailed'", "ReservationOrderCreationFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReservationOrderCreationFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReservationOrderNotEnabled".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReservationOrderNotEnabled'", "ReservationOrderNotEnabled", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReservationOrderNotEnabled");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "CapacityUpdateScopesFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'CapacityUpdateScopesFailed'", "CapacityUpdateScopesFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "CapacityUpdateScopesFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "UnsupportedReservationTerm".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'UnsupportedReservationTerm'", "UnsupportedReservationTerm", global::System.Management.Automation.CompletionResultType.ParameterValue, "UnsupportedReservationTerm");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReservationOrderIdAlreadyExists".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReservationOrderIdAlreadyExists'", "ReservationOrderIdAlreadyExists", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReservationOrderIdAlreadyExists");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "RiskCheckFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'RiskCheckFailed'", "RiskCheckFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "RiskCheckFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "CreateQuoteFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'CreateQuoteFailed'", "CreateQuoteFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "CreateQuoteFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ActivateQuoteFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ActivateQuoteFailed'", "ActivateQuoteFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "ActivateQuoteFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NonsupportedAccountId".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'NonsupportedAccountId'", "NonsupportedAccountId", global::System.Management.Automation.CompletionResultType.ParameterValue, "NonsupportedAccountId");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PaymentInstrumentNotFound".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'PaymentInstrumentNotFound'", "PaymentInstrumentNotFound", global::System.Management.Automation.CompletionResultType.ParameterValue, "PaymentInstrumentNotFound");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "MissingAppliedScopesForSingle".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'MissingAppliedScopesForSingle'", "MissingAppliedScopesForSingle", global::System.Management.Automation.CompletionResultType.ParameterValue, "MissingAppliedScopesForSingle");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NoValidReservationsToReRate".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'NoValidReservationsToReRate'", "NoValidReservationsToReRate", global::System.Management.Automation.CompletionResultType.ParameterValue, "NoValidReservationsToReRate");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "ReRateOnlyAllowedForEA".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'ReRateOnlyAllowedForEA'", "ReRateOnlyAllowedForEA", global::System.Management.Automation.CompletionResultType.ParameterValue, "ReRateOnlyAllowedForEA");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "OperationCannotBePerformedInCurrentState".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'OperationCannotBePerformedInCurrentState'", "OperationCannotBePerformedInCurrentState", global::System.Management.Automation.CompletionResultType.ParameterValue, "OperationCannotBePerformedInCurrentState");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidSingleAppliedScopesCount".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidSingleAppliedScopesCount'", "InvalidSingleAppliedScopesCount", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidSingleAppliedScopesCount");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidFulfillmentRequestParameters".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidFulfillmentRequestParameters'", "InvalidFulfillmentRequestParameters", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidFulfillmentRequestParameters");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "NotSupportedCountry".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'NotSupportedCountry'", "NotSupportedCountry", global::System.Management.Automation.CompletionResultType.ParameterValue, "NotSupportedCountry");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "InvalidRefundQuantity".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'InvalidRefundQuantity'", "InvalidRefundQuantity", global::System.Management.Automation.CompletionResultType.ParameterValue, "InvalidRefundQuantity");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "PurchaseError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'PurchaseError'", "PurchaseError", global::System.Management.Automation.CompletionResultType.ParameterValue, "PurchaseError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingCustomerInputError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingCustomerInputError'", "BillingCustomerInputError", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingCustomerInputError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingPaymentInstrumentSoftError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingPaymentInstrumentSoftError'", "BillingPaymentInstrumentSoftError", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingPaymentInstrumentSoftError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingPaymentInstrumentHardError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingPaymentInstrumentHardError'", "BillingPaymentInstrumentHardError", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingPaymentInstrumentHardError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingTransientError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingTransientError'", "BillingTransientError", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingTransientError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "BillingError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'BillingError'", "BillingError", global::System.Management.Automation.CompletionResultType.ParameterValue, "BillingError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "FulfillmentConfigurationError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'FulfillmentConfigurationError'", "FulfillmentConfigurationError", global::System.Management.Automation.CompletionResultType.ParameterValue, "FulfillmentConfigurationError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "FulfillmentOutOfStockError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'FulfillmentOutOfStockError'", "FulfillmentOutOfStockError", global::System.Management.Automation.CompletionResultType.ParameterValue, "FulfillmentOutOfStockError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "FulfillmentTransientError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'FulfillmentTransientError'", "FulfillmentTransientError", global::System.Management.Automation.CompletionResultType.ParameterValue, "FulfillmentTransientError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "FulfillmentError".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'FulfillmentError'", "FulfillmentError", global::System.Management.Automation.CompletionResultType.ParameterValue, "FulfillmentError");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "CalculatePriceFailed".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'CalculatePriceFailed'", "CalculatePriceFailed", global::System.Management.Automation.CompletionResultType.ParameterValue, "CalculatePriceFailed");
            }
            if (global::System.String.IsNullOrEmpty(wordToComplete) || "AppliedScopesSameAsExisting".StartsWith(wordToComplete, global::System.StringComparison.InvariantCultureIgnoreCase))
            {
                yield return new global::System.Management.Automation.CompletionResult("'AppliedScopesSameAsExisting'", "AppliedScopesSameAsExisting", global::System.Management.Automation.CompletionResultType.ParameterValue, "AppliedScopesSameAsExisting");
            }
        }
    }
}