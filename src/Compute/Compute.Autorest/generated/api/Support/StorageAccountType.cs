// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Support
{

    /// <summary>
    /// Specifies the storage account type to be used to store the image. This property is not updatable.
    /// </summary>
    public partial struct StorageAccountType :
        System.IEquatable<StorageAccountType>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType PremiumLrs = @"Premium_LRS";

        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType StandardLrs = @"Standard_LRS";

        public static Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType StandardZrs = @"Standard_ZRS";

        /// <summary>the value for an instance of the <see cref="StorageAccountType" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to StorageAccountType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="StorageAccountType" />.</param>
        internal static object CreateFrom(object value)
        {
            return new StorageAccountType(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type StorageAccountType</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type StorageAccountType (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is StorageAccountType && Equals((StorageAccountType)obj);
        }

        /// <summary>Returns hashCode for enum StorageAccountType</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="StorageAccountType" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private StorageAccountType(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for StorageAccountType</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to StorageAccountType</summary>
        /// <param name="value">the value to convert to an instance of <see cref="StorageAccountType" />.</param>

        public static implicit operator StorageAccountType(string value)
        {
            return new StorageAccountType(value);
        }

        /// <summary>Implicit operator to convert StorageAccountType to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="StorageAccountType" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum StorageAccountType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e1, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum StorageAccountType</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e1, Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.StorageAccountType e2)
        {
            return e2.Equals(e1);
        }
    }
}