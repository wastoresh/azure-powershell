// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(RefundResponsePropertiesTypeConverter))]
    public partial class RefundResponseProperties
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponseProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RefundResponseProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponseProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponseProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RefundResponseProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RefundResponseProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="RefundResponseProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponseProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RefundResponseProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyResult"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResult = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyResult) content.GetValueForProperty("PolicyResult",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResult, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyResultTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformation = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundBillingInformation) content.GetValueForProperty("BillingInformation",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformation, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundBillingInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SessionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).SessionId = (string) content.GetValueForProperty("SessionId",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).SessionId, global::System.Convert.ToString);
            }
            if (content.Contains("Quantity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).Quantity = (int?) content.GetValueForProperty("Quantity",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).Quantity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingRefundAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingRefundAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingRefundAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingRefundAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PricingRefundAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PricingRefundAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("PricingRefundAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PricingRefundAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyResultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyResultProperty) content.GetValueForProperty("PolicyResultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResultProperty, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyResultPropertyTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingPlan"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingPlan = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationBillingPlan?) content.GetValueForProperty("BillingInformationBillingPlan",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingPlan, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationBillingPlan.CreateFrom);
            }
            if (content.Contains("BillingInformationCompletedTransaction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationCompletedTransaction = (int?) content.GetValueForProperty("BillingInformationCompletedTransaction",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationCompletedTransaction, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingInformationTotalTransaction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationTotalTransaction = (int?) content.GetValueForProperty("BillingInformationTotalTransaction",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationTotalTransaction, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingInformationBillingCurrencyTotalPaidAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyTotalPaidAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyTotalPaidAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyTotalPaidAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingCurrencyProratedAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyProratedAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyProratedAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyProratedAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingCurrencyRemainingCommitmentAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyRemainingCommitmentAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyRemainingCommitmentAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyRemainingCommitmentAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("ConsumedRefundsTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).ConsumedRefundsTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("ConsumedRefundsTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).ConsumedRefundsTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaxRefundLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).MaxRefundLimit = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("MaxRefundLimit",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).MaxRefundLimit, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyError = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyError[]) content.GetValueForProperty("PolicyError",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyErrorTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundResponseProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RefundResponseProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyResult"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResult = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyResult) content.GetValueForProperty("PolicyResult",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResult, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyResultTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformation = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundBillingInformation) content.GetValueForProperty("BillingInformation",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformation, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundBillingInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("SessionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).SessionId = (string) content.GetValueForProperty("SessionId",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).SessionId, global::System.Convert.ToString);
            }
            if (content.Contains("Quantity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).Quantity = (int?) content.GetValueForProperty("Quantity",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).Quantity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingRefundAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingRefundAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingRefundAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingRefundAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PricingRefundAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PricingRefundAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("PricingRefundAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PricingRefundAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyResultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyResultProperty) content.GetValueForProperty("PolicyResultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyResultProperty, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyResultPropertyTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingPlan"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingPlan = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationBillingPlan?) content.GetValueForProperty("BillingInformationBillingPlan",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingPlan, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Support.ReservationBillingPlan.CreateFrom);
            }
            if (content.Contains("BillingInformationCompletedTransaction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationCompletedTransaction = (int?) content.GetValueForProperty("BillingInformationCompletedTransaction",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationCompletedTransaction, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingInformationTotalTransaction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationTotalTransaction = (int?) content.GetValueForProperty("BillingInformationTotalTransaction",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationTotalTransaction, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("BillingInformationBillingCurrencyTotalPaidAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyTotalPaidAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyTotalPaidAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyTotalPaidAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingCurrencyProratedAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyProratedAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyProratedAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyProratedAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingInformationBillingCurrencyRemainingCommitmentAmount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyRemainingCommitmentAmount = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("BillingInformationBillingCurrencyRemainingCommitmentAmount",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).BillingInformationBillingCurrencyRemainingCommitmentAmount, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("ConsumedRefundsTotal"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).ConsumedRefundsTotal = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("ConsumedRefundsTotal",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).ConsumedRefundsTotal, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("MaxRefundLimit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).MaxRefundLimit = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IPrice) content.GetValueForProperty("MaxRefundLimit",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).MaxRefundLimit, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.PriceTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyError"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyError = (Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyError[]) content.GetValueForProperty("PolicyError",((Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundResponsePropertiesInternal)this).PolicyError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.IRefundPolicyError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Models.Api20220301.RefundPolicyErrorTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Reservations.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    [System.ComponentModel.TypeConverter(typeof(RefundResponsePropertiesTypeConverter))]
    public partial interface IRefundResponseProperties

    {

    }
}