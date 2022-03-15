---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstorageaccount
schema: 2.0.0
---

# New-AzStorageAccount

## SYNOPSIS
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String> -Kind <Kind> -Location <String>
 -SkuName <SkuName> [-SubscriptionId <String>] [-AccessTier <AccessTier>]
 [-ActiveDirectoryPropertyAccountType <String>] [-ActiveDirectoryPropertyAzureStorageSid <String>]
 [-ActiveDirectoryPropertyDomainGuid <String>] [-ActiveDirectoryPropertyDomainName <String>]
 [-ActiveDirectoryPropertyDomainSid <String>] [-ActiveDirectoryPropertyForestName <String>]
 [-ActiveDirectoryPropertyNetBiosDomainName <String>] [-ActiveDirectoryPropertySamAccountName <String>]
 [-AllowBlobPublicAccess] [-AllowCrossTenantReplication] [-AllowedCopyScope <AllowedCopyScope>]
 [-AllowSharedKeyAccess]
 [-AzureFileIdentityBasedAuthenticationDefaultSharePermission <DefaultSharePermission>]
 [-AzureFileIdentityBasedAuthenticationDirectoryServiceOption <DirectoryServiceOptions>]
 [-CustomDomainName <String>] [-CustomDomainUseSubDomainName] [-DefaultToOAuthAuthentication]
 [-EnableHttpsTrafficOnly] [-EnableNfsV3] [-Encryption <IEncryption>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <ExtendedLocationTypes>] [-IdentityType <IdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ImmutabilityPolicyAllowProtectedAppendWrite]
 [-ImmutabilityPolicyImmutabilityPeriodSinceCreationInDay <Int32>]
 [-ImmutabilityPolicyState <AccountImmutabilityPolicyState>] [-ImmutableStorageWithVersioningEnabled]
 [-IsHnsEnabled] [-IsLocalUserEnabled] [-IsSftpEnabled] [-KeyPolicyKeyExpirationPeriodInDay <Int32>]
 [-LargeFileSharesState <LargeFileSharesState>] [-MinimumTlsVersion <MinimumTlsVersion>]
 [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetResourceAccessRule <IResourceAccessRule[]>]
 [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RoutingPreferencePublishInternetEndpoint] [-RoutingPreferencePublishMicrosoftEndpoint]
 [-RoutingPreferenceRoutingChoice <RoutingChoice>] [-SasPolicySasExpirationPeriod <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String>
 -Parameter <IStorageAccountCreateParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageAccount -InputObject <IStorageIdentity> -Parameter <IStorageAccountCreateParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageAccount -InputObject <IStorageIdentity> -Kind <Kind> -Location <String> -SkuName <SkuName>
 [-AccessTier <AccessTier>] [-ActiveDirectoryPropertyAccountType <String>]
 [-ActiveDirectoryPropertyAzureStorageSid <String>] [-ActiveDirectoryPropertyDomainGuid <String>]
 [-ActiveDirectoryPropertyDomainName <String>] [-ActiveDirectoryPropertyDomainSid <String>]
 [-ActiveDirectoryPropertyForestName <String>] [-ActiveDirectoryPropertyNetBiosDomainName <String>]
 [-ActiveDirectoryPropertySamAccountName <String>] [-AllowBlobPublicAccess] [-AllowCrossTenantReplication]
 [-AllowedCopyScope <AllowedCopyScope>] [-AllowSharedKeyAccess]
 [-AzureFileIdentityBasedAuthenticationDefaultSharePermission <DefaultSharePermission>]
 [-AzureFileIdentityBasedAuthenticationDirectoryServiceOption <DirectoryServiceOptions>]
 [-CustomDomainName <String>] [-CustomDomainUseSubDomainName] [-DefaultToOAuthAuthentication]
 [-EnableHttpsTrafficOnly] [-EnableNfsV3] [-Encryption <IEncryption>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <ExtendedLocationTypes>] [-IdentityType <IdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ImmutabilityPolicyAllowProtectedAppendWrite]
 [-ImmutabilityPolicyImmutabilityPeriodSinceCreationInDay <Int32>]
 [-ImmutabilityPolicyState <AccountImmutabilityPolicyState>] [-ImmutableStorageWithVersioningEnabled]
 [-IsHnsEnabled] [-IsLocalUserEnabled] [-IsSftpEnabled] [-KeyPolicyKeyExpirationPeriodInDay <Int32>]
 [-LargeFileSharesState <LargeFileSharesState>] [-MinimumTlsVersion <MinimumTlsVersion>]
 [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetResourceAccessRule <IResourceAccessRule[]>]
 [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-RoutingPreferencePublishInternetEndpoint] [-RoutingPreferencePublishMicrosoftEndpoint]
 [-RoutingPreferenceRoutingChoice <RoutingChoice>] [-SasPolicySasExpirationPeriod <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccessTier
Required for storage accounts where kind = BlobStorage.
The access tier used for billing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyAccountType
Specifies the Active Directory account type for Azure Storage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyAzureStorageSid
Specifies the security identifier (SID) for Azure Storage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyDomainGuid
Specifies the domain GUID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyDomainName
Specifies the primary domain that the AD DNS server is authoritative for.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyDomainSid
Specifies the security identifier (SID).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyForestName
Specifies the Active Directory forest to get.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertyNetBiosDomainName
Specifies the NetBIOS domain name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActiveDirectoryPropertySamAccountName
Specifies the Active Directory SAMAccountName for Azure Storage.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowBlobPublicAccess
Allow or disallow public access to all blobs or containers in the storage account.
The default interpretation is true for this property.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowCrossTenantReplication
Allow or disallow cross AAD tenant object replication.
The default interpretation is true for this property.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowedCopyScope
Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AllowedCopyScope
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowSharedKeyAccess
Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key.
If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD).
The default value is null, which is equivalent to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileIdentityBasedAuthenticationDefaultSharePermission
Default share permission for users using Kerberos authentication if RBAC role is not assigned.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultSharePermission
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileIdentityBasedAuthenticationDirectoryServiceOption
Indicates the directory service used.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DirectoryServiceOptions
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomDomainName
Gets or sets the custom domain name assigned to the storage account.
Name is the CNAME source.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomDomainUseSubDomainName
Indicates whether indirect CName validation is enabled.
Default value is false.
This should only be set on updates.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultToOAuthAuthentication
A boolean flag which indicates whether the default authentication is OAuth or not.
The default interpretation is false for this property.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableHttpsTrafficOnly
Allows https traffic only to storage service if sets to true.
The default value is true since API version 2019-04-01.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableNfsV3
NFS 3.0 protocol support enabled if set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Encryption
Encryption settings to be used for server-side encryption for the storage account.
To construct, see NOTES section for ENCRYPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IEncryption
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.ExtendedLocationTypes
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.IdentityType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
Gets or sets a list of key value pairs that describe the set of User Assigned identities that will be used with this storage account.
The key is the ARM resource identifier of the identity.
Only 1 User Assigned identity is permitted here.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityPolicyAllowProtectedAppendWrite
This property can only be changed for disabled and unlocked time-based retention policies.
When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance.
Only new blocks can be added and any existing blocks cannot be modified or deleted.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityPolicyImmutabilityPeriodSinceCreationInDay
The immutability period for the blobs in the container since the policy creation, in days.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityPolicyState
The ImmutabilityPolicy state defines the mode of the policy.
Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time.
A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states.
Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccountImmutabilityPolicyState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutableStorageWithVersioningEnabled
A boolean flag which enables account-level immutability.
All the containers under such an account have object-level immutability enabled by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsHnsEnabled
Account HierarchicalNamespace enabled if sets to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsLocalUserEnabled
Enables local users feature, if set to true

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSftpEnabled
Enables Secure File Transfer Protocol, if set to true

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyPolicyKeyExpirationPeriodInDay
The key expiration period in days.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Required.
Indicates the type of storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LargeFileSharesState
Allow large file shares if sets to Enabled.
It cannot be disabled once it is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.LargeFileSharesState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Required.
Gets or sets the location of the resource.
This will be one of the supported and registered Azure Geo Regions (e.g.
West US, East US, Southeast Asia, etc.).
The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersion
Set the minimum TLS version to be permitted on requests to storage.
The default interpretation is TLS 1.0 for this property.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.MinimumTlsVersion
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetBypass
Specifies whether traffic is bypassed for Logging/Metrics/AzureServices.
Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetDefaultAction
Specifies the default action of allow or deny when no other rules match.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetIPRule
Sets the IP ACL rules
To construct, see NOTES section for NETWORKRULESETIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IIPRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetResourceAccessRule
Sets the resource access rules
To construct, see NOTES section for NETWORKRULESETRESOURCEACCESSRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IResourceAccessRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRuleSetVirtualNetworkRule
Sets the virtual network rules
To construct, see NOTES section for NETWORKRULESETVIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IVirtualNetworkRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters used when creating a storage account.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IStorageAccountCreateParameters
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PublicNetworkAccess
Allow or disallow public network access to Storage Account.
Value is optional but if passed in, must be 'Enabled' or 'Disabled'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.PublicNetworkAccess
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingPreferencePublishInternetEndpoint
A boolean flag which indicates whether internet routing storage endpoints are to be published

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingPreferencePublishMicrosoftEndpoint
A boolean flag which indicates whether microsoft routing storage endpoints are to be published

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingPreferenceRoutingChoice
Routing Choice defines the kind of network routing opted by the user.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.RoutingChoice
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SasPolicySasExpirationPeriod
The SAS expiration period, DD.HH:MM:SS.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The SKU name.
Required for account creation; optional for update.
Note that in older versions, SKU name was called accountType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets a list of key value pairs that describe the resource.
These tags can be used for viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IStorageAccountCreateParameters

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IStorageAccount

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ENCRYPTION <IEncryption>: Encryption settings to be used for server-side encryption for the storage account.
  - `KeySource <KeySource>`: The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
  - `[BlobEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
  - `[BlobKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
  - `[FileEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
  - `[FileKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
  - `[IdentityEncryptionFederatedIdentityClientId <String>]`: ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.
  - `[IdentityEncryptionUserAssignedIdentity <String>]`: Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account.
  - `[KeyVaultPropertyKeyName <String>]`: The name of KeyVault key.
  - `[KeyVaultPropertyKeyVaultUri <String>]`: The Uri of KeyVault.
  - `[KeyVaultPropertyKeyVersion <String>]`: The version of KeyVault key.
  - `[QueueEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
  - `[QueueKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
  - `[RequireInfrastructureEncryption <Boolean?>]`: A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
  - `[TableEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
  - `[TableKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.

INPUTOBJECT <IStorageIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  - `[BlobInventoryPolicyName <BlobInventoryPolicyName?>]`: The name of the storage account blob inventory policy. It should always be 'default'
  - `[BlobServicesName <BlobServicesName?>]`: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  - `[ContainerName <String>]`: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[DeletedAccountName <String>]`: Name of the deleted storage account.
  - `[EncryptionScopeName <String>]`: The name of the encryption scope within the specified storage account. Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[FileServicesName <FileServicesName?>]`: The name of the file Service within the specified storage account. File Service Name must be "default"
  - `[Id <String>]`: Resource identity path
  - `[ImmutabilityPolicyName <ImmutabilityPolicyName?>]`: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  - `[Location <String>]`: The location of the deleted storage account.
  - `[ManagementPolicyName <ManagementPolicyName?>]`: The name of the Storage Account Management Policy. It should always be 'default'
  - `[ObjectReplicationPolicyId <String>]`: For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the Azure resource
  - `[ResourceGroupName <String>]`: The name of the resource group within the user's subscription. The name is case insensitive.
  - `[ShareName <String>]`: The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[Username <String>]`: The name of local user. The username must contain lowercase letters and numbers only. It must be unique only within the storage account.

NETWORKRULESETIPRULE <IIPRule[]>: Sets the IP ACL rules
  - `IPAddressOrRange <String>`: Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
  - `[Action <Action?>]`: The action of IP ACL rule.

NETWORKRULESETRESOURCEACCESSRULE <IResourceAccessRule[]>: Sets the resource access rules
  - `[ResourceId <String>]`: Resource Id
  - `[TenantId <String>]`: Tenant Id

NETWORKRULESETVIRTUALNETWORKRULE <IVirtualNetworkRule[]>: Sets the virtual network rules
  - `VirtualNetworkResourceId <String>`: Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
  - `[Action <Action?>]`: The action of virtual network rule.
  - `[State <State?>]`: Gets the state of virtual network rule.

PARAMETER <IStorageAccountCreateParameters>: The parameters used when creating a storage account.
  - `Kind <Kind>`: Required. Indicates the type of storage account.
  - `Location <String>`: Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.
  - `SkuName <SkuName>`: The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
  - `[AccessTier <AccessTier?>]`: Required for storage accounts where kind = BlobStorage. The access tier used for billing.
  - `[ActiveDirectoryPropertyAccountType <String>]`: Specifies the Active Directory account type for Azure Storage.
  - `[ActiveDirectoryPropertyAzureStorageSid <String>]`: Specifies the security identifier (SID) for Azure Storage.
  - `[ActiveDirectoryPropertyDomainGuid <String>]`: Specifies the domain GUID.
  - `[ActiveDirectoryPropertyDomainName <String>]`: Specifies the primary domain that the AD DNS server is authoritative for.
  - `[ActiveDirectoryPropertyDomainSid <String>]`: Specifies the security identifier (SID).
  - `[ActiveDirectoryPropertyForestName <String>]`: Specifies the Active Directory forest to get.
  - `[ActiveDirectoryPropertyNetBiosDomainName <String>]`: Specifies the NetBIOS domain name.
  - `[ActiveDirectoryPropertySamAccountName <String>]`: Specifies the Active Directory SAMAccountName for Azure Storage.
  - `[AllowBlobPublicAccess <Boolean?>]`: Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property.
  - `[AllowCrossTenantReplication <Boolean?>]`: Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property.
  - `[AllowSharedKeyAccess <Boolean?>]`: Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true.
  - `[AllowedCopyScope <AllowedCopyScope?>]`: Restrict copy to and from Storage Accounts within an AAD tenant or with Private Links to the same VNet.
  - `[AzureFileIdentityBasedAuthenticationDefaultSharePermission <DefaultSharePermission?>]`: Default share permission for users using Kerberos authentication if RBAC role is not assigned.
  - `[AzureFileIdentityBasedAuthenticationDirectoryServiceOption <DirectoryServiceOptions?>]`: Indicates the directory service used.
  - `[CustomDomainName <String>]`: Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
  - `[CustomDomainUseSubDomainName <Boolean?>]`: Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
  - `[DefaultToOAuthAuthentication <Boolean?>]`: A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property.
  - `[EnableHttpsTrafficOnly <Boolean?>]`: Allows https traffic only to storage service if sets to true. The default value is true since API version 2019-04-01.
  - `[EnableNfsV3 <Boolean?>]`: NFS 3.0 protocol support enabled if set to true.
  - `[Encryption <IEncryption>]`: Encryption settings to be used for server-side encryption for the storage account.
    - `KeySource <KeySource>`: The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
    - `[BlobEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
    - `[BlobKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
    - `[FileEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
    - `[FileKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
    - `[IdentityEncryptionFederatedIdentityClientId <String>]`: ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.
    - `[IdentityEncryptionUserAssignedIdentity <String>]`: Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account.
    - `[KeyVaultPropertyKeyName <String>]`: The name of KeyVault key.
    - `[KeyVaultPropertyKeyVaultUri <String>]`: The Uri of KeyVault.
    - `[KeyVaultPropertyKeyVersion <String>]`: The version of KeyVault key.
    - `[QueueEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
    - `[QueueKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
    - `[RequireInfrastructureEncryption <Boolean?>]`: A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
    - `[TableEnabled <Boolean?>]`: A boolean indicating whether or not the service encrypts the data as it is stored. Encryption at rest is enabled by default today and cannot be disabled.
    - `[TableKeyType <KeyType?>]`: Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used.
  - `[ExtendedLocationName <String>]`: The name of the extended location.
  - `[ExtendedLocationType <ExtendedLocationTypes?>]`: The type of the extended location.
  - `[IdentityType <IdentityType?>]`: The identity type.
  - `[IdentityUserAssignedIdentity <IIdentityUserAssignedIdentities>]`: Gets or sets a list of key value pairs that describe the set of User Assigned identities that will be used with this storage account. The key is the ARM resource identifier of the identity. Only 1 User Assigned identity is permitted here.
    - `[(Any) <IUserAssignedIdentity>]`: This indicates any property can be added to this object.
  - `[ImmutabilityPolicyAllowProtectedAppendWrite <Boolean?>]`: This property can only be changed for disabled and unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted.
  - `[ImmutabilityPolicyImmutabilityPeriodSinceCreationInDay <Int32?>]`: The immutability period for the blobs in the container since the policy creation, in days.
  - `[ImmutabilityPolicyState <AccountImmutabilityPolicyState?>]`: The ImmutabilityPolicy state defines the mode of the policy. Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time. A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted.
  - `[ImmutableStorageWithVersioningEnabled <Boolean?>]`: A boolean flag which enables account-level immutability. All the containers under such an account have object-level immutability enabled by default.
  - `[IsHnsEnabled <Boolean?>]`: Account HierarchicalNamespace enabled if sets to true.
  - `[IsLocalUserEnabled <Boolean?>]`: Enables local users feature, if set to true
  - `[IsSftpEnabled <Boolean?>]`: Enables Secure File Transfer Protocol, if set to true
  - `[KeyPolicyKeyExpirationPeriodInDay <Int32?>]`: The key expiration period in days.
  - `[LargeFileSharesState <LargeFileSharesState?>]`: Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled.
  - `[MinimumTlsVersion <MinimumTlsVersion?>]`: Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property.
  - `[NetworkRuleSetBypass <Bypass?>]`: Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
  - `[NetworkRuleSetDefaultAction <DefaultAction?>]`: Specifies the default action of allow or deny when no other rules match.
  - `[NetworkRuleSetIPRule <IIPRule[]>]`: Sets the IP ACL rules
    - `IPAddressOrRange <String>`: Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
    - `[Action <Action?>]`: The action of IP ACL rule.
  - `[NetworkRuleSetResourceAccessRule <IResourceAccessRule[]>]`: Sets the resource access rules
    - `[ResourceId <String>]`: Resource Id
    - `[TenantId <String>]`: Tenant Id
  - `[NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]`: Sets the virtual network rules
    - `VirtualNetworkResourceId <String>`: Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
    - `[Action <Action?>]`: The action of virtual network rule.
    - `[State <State?>]`: Gets the state of virtual network rule.
  - `[PublicNetworkAccess <PublicNetworkAccess?>]`: Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'.
  - `[RoutingPreferencePublishInternetEndpoint <Boolean?>]`: A boolean flag which indicates whether internet routing storage endpoints are to be published
  - `[RoutingPreferencePublishMicrosoftEndpoint <Boolean?>]`: A boolean flag which indicates whether microsoft routing storage endpoints are to be published
  - `[RoutingPreferenceRoutingChoice <RoutingChoice?>]`: Routing Choice defines the kind of network routing opted by the user.
  - `[SasPolicySasExpirationPeriod <String>]`: The SAS expiration period, DD.HH:MM:SS.
  - `[Tag <IStorageAccountCreateParametersTags>]`: Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

