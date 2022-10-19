// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support
{

    /// <summary>
    /// Grouping matching method. When method is Selected at least one of groupByEntities, groupByAlertDetails, groupByCustomDetails
    /// must be provided and not empty.
    /// </summary>
    public partial struct MatchingMethod :
        System.IEquatable<MatchingMethod>
    {
        /// <summary>Grouping alerts into a single incident if all the entities match</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod AllEntities = @"AllEntities";

        /// <summary>Grouping any alerts triggered by this rule into a single incident</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod AnyAlert = @"AnyAlert";

        /// <summary>
        /// Grouping alerts into a single incident if the selected entities, custom details and alert details match
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod Selected = @"Selected";

        /// <summary>the value for an instance of the <see cref="MatchingMethod" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to MatchingMethod</summary>
        /// <param name="value">the value to convert to an instance of <see cref="MatchingMethod" />.</param>
        internal static object CreateFrom(object value)
        {
            return new MatchingMethod(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type MatchingMethod</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type MatchingMethod (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is MatchingMethod && Equals((MatchingMethod)obj);
        }

        /// <summary>Returns hashCode for enum MatchingMethod</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="MatchingMethod"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private MatchingMethod(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for MatchingMethod</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to MatchingMethod</summary>
        /// <param name="value">the value to convert to an instance of <see cref="MatchingMethod" />.</param>

        public static implicit operator MatchingMethod(string value)
        {
            return new MatchingMethod(value);
        }

        /// <summary>Implicit operator to convert MatchingMethod to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="MatchingMethod" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum MatchingMethod</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e1, Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum MatchingMethod</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e1, Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MatchingMethod e2)
        {
            return e2.Equals(e1);
        }
    }
}