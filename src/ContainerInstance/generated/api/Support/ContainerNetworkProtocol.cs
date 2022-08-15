// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support
{

    /// <summary>The protocol associated with the port.</summary>
    public partial struct ContainerNetworkProtocol :
        System.IEquatable<ContainerNetworkProtocol>
    {
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol Tcp = @"TCP";

        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol Udp = @"UDP";

        /// <summary>the value for an instance of the <see cref="ContainerNetworkProtocol" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Creates an instance of the <see cref="ContainerNetworkProtocol"/> Enum class.</summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private ContainerNetworkProtocol(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Conversion from arbitrary object to ContainerNetworkProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ContainerNetworkProtocol" />.</param>
        internal static object CreateFrom(object value)
        {
            return new ContainerNetworkProtocol(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type ContainerNetworkProtocol</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type ContainerNetworkProtocol (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is ContainerNetworkProtocol && Equals((ContainerNetworkProtocol)obj);
        }

        /// <summary>Returns hashCode for enum ContainerNetworkProtocol</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for ContainerNetworkProtocol</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to ContainerNetworkProtocol</summary>
        /// <param name="value">the value to convert to an instance of <see cref="ContainerNetworkProtocol" />.</param>

        public static implicit operator ContainerNetworkProtocol(string value)
        {
            return new ContainerNetworkProtocol(value);
        }

        /// <summary>Implicit operator to convert ContainerNetworkProtocol to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="ContainerNetworkProtocol" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum ContainerNetworkProtocol</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum ContainerNetworkProtocol</summary>
        /// <param name="e1">the value to compare against <paramref name="e2" /></param>
        /// <param name="e2">the value to compare against <paramref name="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e1, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerNetworkProtocol e2)
        {
            return e2.Equals(e1);
        }
    }
}