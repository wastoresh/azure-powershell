// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.PowerShell;

    /// <summary>Specifications of the Metrics for Azure Monitoring</summary>
    [System.ComponentModel.TypeConverter(typeof(MetricSpecificationTypeConverter))]
    public partial class MetricSpecification
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricSpecification"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecification"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecification DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MetricSpecification(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricSpecification"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecification"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecification DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MetricSpecification(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MetricSpecification" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="MetricSpecification" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecification FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricSpecification"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MetricSpecification(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayDescription, global::System.Convert.ToString);
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("SupportedAggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedAggregationType = (string[]) content.GetValueForProperty("SupportedAggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedAggregationType, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedTimeGrainType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedTimeGrainType = (string[]) content.GetValueForProperty("SupportedTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedTimeGrainType, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EnableRegionalMdmAccount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).EnableRegionalMdmAccount = (bool?) content.GetValueForProperty("EnableRegionalMdmAccount",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).EnableRegionalMdmAccount, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SourceMdmAccount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmAccount = (string) content.GetValueForProperty("SourceMdmAccount",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmAccount, global::System.Convert.ToString);
            }
            if (content.Contains("SourceMdmNamespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmNamespace = (string) content.GetValueForProperty("SourceMdmNamespace",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmNamespace, global::System.Convert.ToString);
            }
            if (content.Contains("MetricFilterPattern"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).MetricFilterPattern = (string) content.GetValueForProperty("MetricFilterPattern",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).MetricFilterPattern, global::System.Convert.ToString);
            }
            if (content.Contains("FillGapWithZero"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).FillGapWithZero = (bool?) content.GetValueForProperty("FillGapWithZero",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).FillGapWithZero, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("Category"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Category = (string) content.GetValueForProperty("Category",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Category, global::System.Convert.ToString);
            }
            if (content.Contains("InternalMetricName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).InternalMetricName = (string) content.GetValueForProperty("InternalMetricName",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).InternalMetricName, global::System.Convert.ToString);
            }
            if (content.Contains("Dimension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Dimension = (Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricDimension[]) content.GetValueForProperty("Dimension",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Dimension, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricDimension>(__y, Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricDimensionTypeConverter.ConvertFrom));
            }
            if (content.Contains("LockedAggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).LockedAggregationType = (string) content.GetValueForProperty("LockedAggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).LockedAggregationType, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricSpecification"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MetricSpecification(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayDescription"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).DisplayDescription, global::System.Convert.ToString);
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("SupportedAggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedAggregationType = (string[]) content.GetValueForProperty("SupportedAggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedAggregationType, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedTimeGrainType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedTimeGrainType = (string[]) content.GetValueForProperty("SupportedTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SupportedTimeGrainType, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("EnableRegionalMdmAccount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).EnableRegionalMdmAccount = (bool?) content.GetValueForProperty("EnableRegionalMdmAccount",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).EnableRegionalMdmAccount, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SourceMdmAccount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmAccount = (string) content.GetValueForProperty("SourceMdmAccount",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmAccount, global::System.Convert.ToString);
            }
            if (content.Contains("SourceMdmNamespace"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmNamespace = (string) content.GetValueForProperty("SourceMdmNamespace",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).SourceMdmNamespace, global::System.Convert.ToString);
            }
            if (content.Contains("MetricFilterPattern"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).MetricFilterPattern = (string) content.GetValueForProperty("MetricFilterPattern",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).MetricFilterPattern, global::System.Convert.ToString);
            }
            if (content.Contains("FillGapWithZero"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).FillGapWithZero = (bool?) content.GetValueForProperty("FillGapWithZero",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).FillGapWithZero, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("Category"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Category = (string) content.GetValueForProperty("Category",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Category, global::System.Convert.ToString);
            }
            if (content.Contains("InternalMetricName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).InternalMetricName = (string) content.GetValueForProperty("InternalMetricName",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).InternalMetricName, global::System.Convert.ToString);
            }
            if (content.Contains("Dimension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Dimension = (Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricDimension[]) content.GetValueForProperty("Dimension",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).Dimension, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricDimension>(__y, Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.MetricDimensionTypeConverter.ConvertFrom));
            }
            if (content.Contains("LockedAggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).LockedAggregationType = (string) content.GetValueForProperty("LockedAggregationType",((Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Models.Api20210301Preview.IMetricSpecificationInternal)this).LockedAggregationType, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MixedReality.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Specifications of the Metrics for Azure Monitoring
    [System.ComponentModel.TypeConverter(typeof(MetricSpecificationTypeConverter))]
    public partial interface IMetricSpecification

    {

    }
}