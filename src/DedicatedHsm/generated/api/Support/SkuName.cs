// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support
{

    /// <summary>SKU of the dedicated HSM</summary>
    public partial struct SkuName :
        System.IEquatable<SkuName>
    {
        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 1 local master key which
        /// supports up to 250 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk1Cps250 = @"payShield10K_LMK1_CPS250";

        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 1 local master key which
        /// supports up to 2500 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk1Cps2500 = @"payShield10K_LMK1_CPS2500";

        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 1 local master key which
        /// supports up to 60 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk1Cps60 = @"payShield10K_LMK1_CPS60";

        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 2 local master keys which
        /// supports up to 250 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk2Cps250 = @"payShield10K_LMK2_CPS250";

        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 2 local master keys which
        /// supports up to 2500 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk2Cps2500 = @"payShield10K_LMK2_CPS2500";

        /// <summary>
        /// The dedicated HSM is a payShield 10K, model PS10-D, 10Gb Ethernet Hardware Platform device with 2 local master keys which
        /// supports up to 60 calls per second.
        /// </summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName PayShield10KLmk2Cps60 = @"payShield10K_LMK2_CPS60";

        /// <summary>The dedicated HSM is a Safenet Luna Network HSM A790 device.</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName SafeNetLunaNetworkHsmA790 = @"SafeNet Luna Network HSM A790";

        /// <summary>the value for an instance of the <see cref="SkuName" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to SkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SkuName" />.</param>
        internal static object CreateFrom(object value)
        {
            return new SkuName(global::System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type SkuName</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type SkuName (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is SkuName && Equals((SkuName)obj);
        }

        /// <summary>Returns hashCode for enum SkuName</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Creates an instance of the <see cref="SkuName" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private SkuName(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns string representation for SkuName</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to SkuName</summary>
        /// <param name="value">the value to convert to an instance of <see cref="SkuName" />.</param>

        public static implicit operator SkuName(string value)
        {
            return new SkuName(value);
        }

        /// <summary>Implicit operator to convert SkuName to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="SkuName" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum SkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e1, Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum SkuName</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e1, Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Support.SkuName e2)
        {
            return e2.Equals(e1);
        }
    }
}