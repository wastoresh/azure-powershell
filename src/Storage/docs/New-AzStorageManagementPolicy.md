---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstoragemanagementpolicy
schema: 2.0.0
---

# New-AzStorageManagementPolicy

## SYNOPSIS
Sets the managementpolicy to the specified storage account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageManagementPolicy -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PolicyRule <IManagementPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzStorageManagementPolicy -AccountName <String> -ResourceGroupName <String> -Property <IManagementPolicy>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageManagementPolicy -InputObject <IStorageIdentity> -Property <IManagementPolicy>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageManagementPolicy -InputObject <IStorageIdentity> [-PolicyRule <IManagementPolicyRule[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets the managementpolicy to the specified storage account.

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

### -PolicyRule
The Storage Account ManagementPolicies Rules.
See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
To construct, see NOTES section for POLICYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IManagementPolicyRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The Get Storage Account ManagementPolicies operation response.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IManagementPolicy
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IManagementPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IManagementPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


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

POLICYRULE <IManagementPolicyRule[]>: The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
  - `DefinitionAction <IManagementPolicyAction>`: An object that defines the action set.
    - `[BaseBlobEnableAutoTierToHotFromCool <Boolean?>]`: This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
    - `[DeleteDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[DeleteDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[SnapshotDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[SnapshotTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[SnapshotTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[TierToArchiveDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[TierToArchiveDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[TierToCoolDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[TierToCoolDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[VersionDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[VersionTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[VersionTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
  - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
  - `[Enabled <Boolean?>]`: Rule is enabled if set to true.
  - `[FilterBlobIndexMatch <ITagFilter[]>]`: An array of blob index tag based filters, there can be at most 10 tag filters
    - `Name <String>`: This is the filter tag name, it can have 1 - 128 characters
    - `Op <String>`: This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported
    - `Value <String>`: This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters
  - `[FilterBlobType <String[]>]`: An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.
  - `[FilterPrefixMatch <String[]>]`: An array of strings for prefixes to be match.

PROPERTY <IManagementPolicy>: The Get Storage Account ManagementPolicies operation response.
  - `[PolicyRule <IManagementPolicyRule[]>]`: The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    - `DefinitionAction <IManagementPolicyAction>`: An object that defines the action set.
      - `[BaseBlobEnableAutoTierToHotFromCool <Boolean?>]`: This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
      - `[DeleteDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
      - `[DeleteDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
      - `[SnapshotDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
      - `[SnapshotTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
      - `[SnapshotTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
      - `[TierToArchiveDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
      - `[TierToArchiveDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
      - `[TierToCoolDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
      - `[TierToCoolDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
      - `[VersionDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
      - `[VersionTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
      - `[VersionTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
    - `[Enabled <Boolean?>]`: Rule is enabled if set to true.
    - `[FilterBlobIndexMatch <ITagFilter[]>]`: An array of blob index tag based filters, there can be at most 10 tag filters
      - `Name <String>`: This is the filter tag name, it can have 1 - 128 characters
      - `Op <String>`: This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported
      - `Value <String>`: This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters
    - `[FilterBlobType <String[]>]`: An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.
    - `[FilterPrefixMatch <String[]>]`: An array of strings for prefixes to be match.

## RELATED LINKS

