// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support
{

    public partial struct ReportGranularityType :
        System.IEquatable<ReportGranularityType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType Daily = @"Daily";

        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType Monthly = @"Monthly";

        /// <summary>the value for an instance of the <see cref="ReportGranularityType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to ReportGranularityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ReportGranularityType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new ReportGranularityType(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ReportGranularityType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ReportGranularityType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ReportGranularityType && Equals((ReportGranularityType)obj);
        }

        /// <summary>Returns hashCode for enum ReportGranularityType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="ReportGranularityType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ReportGranularityType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for ReportGranularityType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ReportGranularityType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ReportGranularityType" />.</param>

        public static implicit operator ReportGranularityType(string value)
        {
            return new ReportGranularityType(value);
        }

        /// <summary>Implicit operator to convert ReportGranularityType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ReportGranularityType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ReportGranularityType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e1, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ReportGranularityType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e1, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.ReportGranularityType e2)
        {
            return e2.Equals(e1);
        }
    }
}