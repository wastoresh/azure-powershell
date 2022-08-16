// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support
{

    public partial struct ErrorResponseCode :
        System.IEquatable<ErrorResponseCode>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ActivateQuoteFailed = @"ActivateQuoteFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode AppliedScopesNotAssociatedWithCommerceAccount = @"AppliedScopesNotAssociatedWithCommerceAccount";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode AppliedScopesSameAsExisting = @"AppliedScopesSameAsExisting";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode AuthorizationFailed = @"AuthorizationFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BadRequest = @"BadRequest";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingCustomerInputError = @"BillingCustomerInputError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingError = @"BillingError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingPaymentInstrumentHardError = @"BillingPaymentInstrumentHardError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingPaymentInstrumentSoftError = @"BillingPaymentInstrumentSoftError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingScopeIdCannotBeChanged = @"BillingScopeIdCannotBeChanged";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode BillingTransientError = @"BillingTransientError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode CalculatePriceFailed = @"CalculatePriceFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode CapacityUpdateScopesFailed = @"CapacityUpdateScopesFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ClientCertificateThumbprintNotSet = @"ClientCertificateThumbprintNotSet";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode CreateQuoteFailed = @"CreateQuoteFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode Forbidden = @"Forbidden";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode FulfillmentConfigurationError = @"FulfillmentConfigurationError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode FulfillmentError = @"FulfillmentError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode FulfillmentOutOfStockError = @"FulfillmentOutOfStockError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode FulfillmentTransientError = @"FulfillmentTransientError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode HttpMethodNotSupported = @"HttpMethodNotSupported";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InternalServerError = @"InternalServerError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidAccessToken = @"InvalidAccessToken";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidFulfillmentRequestParameters = @"InvalidFulfillmentRequestParameters";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidHealthCheckType = @"InvalidHealthCheckType";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidLocationId = @"InvalidLocationId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidRefundQuantity = @"InvalidRefundQuantity";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidRequestContent = @"InvalidRequestContent";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidRequestUri = @"InvalidRequestUri";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidReservationId = @"InvalidReservationId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidReservationOrderId = @"InvalidReservationOrderId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidSingleAppliedScopesCount = @"InvalidSingleAppliedScopesCount";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidSubscriptionId = @"InvalidSubscriptionId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode InvalidTenantId = @"InvalidTenantId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode MissingAppliedScopesForSingle = @"MissingAppliedScopesForSingle";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode MissingTenantId = @"MissingTenantId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode NoValidReservationsToReRate = @"NoValidReservationsToReRate";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode NonsupportedAccountId = @"NonsupportedAccountId";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode NotSpecified = @"NotSpecified";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode NotSupportedCountry = @"NotSupportedCountry";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode OperationCannotBePerformedInCurrentState = @"OperationCannotBePerformedInCurrentState";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode OperationFailed = @"OperationFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode PatchValuesSameAsExisting = @"PatchValuesSameAsExisting";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode PaymentInstrumentNotFound = @"PaymentInstrumentNotFound";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode PurchaseError = @"PurchaseError";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReRateOnlyAllowedForEa = @"ReRateOnlyAllowedForEA";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReservationIdNotInReservationOrder = @"ReservationIdNotInReservationOrder";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReservationOrderCreationFailed = @"ReservationOrderCreationFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReservationOrderIdAlreadyExists = @"ReservationOrderIdAlreadyExists";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReservationOrderNotEnabled = @"ReservationOrderNotEnabled";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ReservationOrderNotFound = @"ReservationOrderNotFound";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode RiskCheckFailed = @"RiskCheckFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode RoleAssignmentCreationFailed = @"RoleAssignmentCreationFailed";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode ServerTimeout = @"ServerTimeout";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode UnauthenticatedRequestsThrottled = @"UnauthenticatedRequestsThrottled";

        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode UnsupportedReservationTerm = @"UnsupportedReservationTerm";

        /// <summary>the value for an instance of the <see cref="ErrorResponseCode" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ErrorResponseCode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ErrorResponseCode" />.</param>
        internal static object CreateFrom(object value)
        {
            return new ErrorResponseCode(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ErrorResponseCode</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ErrorResponseCode (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ErrorResponseCode && Equals((ErrorResponseCode)obj);
        }

        /// <summary>Creates an instance of the <see cref="ErrorResponseCode"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ErrorResponseCode(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum ErrorResponseCode</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ErrorResponseCode</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ErrorResponseCode</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ErrorResponseCode" />.</param>

        public static implicit operator ErrorResponseCode(string value)
        {
            return new ErrorResponseCode(value);
        }

        /// <summary>Implicit operator to convert ErrorResponseCode to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ErrorResponseCode" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ErrorResponseCode</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e1, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ErrorResponseCode</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e1, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ErrorResponseCode e2)
        {
            return e2.Equals(e1);
        }
    }
}