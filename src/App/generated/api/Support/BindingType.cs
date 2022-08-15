// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.App.Support
{

    /// <summary>Custom Domain binding type.</summary>
    public partial struct BindingType :
        System.IEquatable<BindingType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType Disabled = @"Disabled";

        public static Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType SniEnabled = @"SniEnabled";

        /// <summary>the value for an instance of the <see cref="BindingType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="BindingType"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private BindingType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to BindingType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="BindingType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new BindingType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type BindingType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type BindingType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is BindingType && Equals((BindingType)obj);
        }

        /// <summary>Returns hashCode for enum BindingType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for BindingType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to BindingType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="BindingType" />.</param>

        public static implicit operator BindingType(string value)
        {
            return new BindingType(value);
        }

        /// <summary>Implicit operator to convert BindingType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="BindingType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum BindingType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e1, Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum BindingType</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e1, Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType e2)
        {
            return e2.Equals(e1);
        }
    }
}