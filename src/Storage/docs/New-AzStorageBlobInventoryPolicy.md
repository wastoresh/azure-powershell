---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstorageblobinventorypolicy
schema: 2.0.0
---

# New-AzStorageBlobInventoryPolicy

## SYNOPSIS
Sets the blob inventory policy to the specified storage account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageBlobInventoryPolicy -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PolicyEnabled] [-PolicyRule <IBlobInventoryPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzStorageBlobInventoryPolicy -AccountName <String> -ResourceGroupName <String>
 -Property <IBlobInventoryPolicy> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageBlobInventoryPolicy -InputObject <IStorageIdentity> -Property <IBlobInventoryPolicy>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageBlobInventoryPolicy -InputObject <IStorageIdentity> [-PolicyEnabled]
 [-PolicyRule <IBlobInventoryPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Sets the blob inventory policy to the specified storage account.

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

### -PolicyEnabled
Policy is enabled if set to true.

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

### -PolicyRule
The storage account blob inventory policy rules.
The rule is applied when it is enabled.
To construct, see NOTES section for POLICYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IBlobInventoryPolicyRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
The storage account blob inventory policy.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IBlobInventoryPolicy
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IBlobInventoryPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IBlobInventoryPolicy

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

POLICYRULE <IBlobInventoryPolicyRule[]>: The storage account blob inventory policy rules. The rule is applied when it is enabled.
  - `DefinitionFormat <Format>`: This is a required field, it specifies the format for the inventory files.
  - `DefinitionObjectType <ObjectType>`: This is a required field. This field specifies the scope of the inventory created either at the blob or container level.
  - `DefinitionSchedule <Schedule>`: This is a required field. This field is used to schedule an inventory formation.
  - `DefinitionSchemaField <String[]>`: This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts
  - `Destination <String>`: Container name where blob inventory files are stored. Must be pre-created.
  - `Enabled <Boolean>`: Rule is enabled when set to true.
  - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
  - `[FilterBlobType <String[]>]`: An array of predefined enum values. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs. This field is required when definition.objectType property is set to 'Blob'.
  - `[FilterIncludeBlobVersion <Boolean?>]`: Includes blob versions in blob inventory when value is set to true. The definition.schemaFields values 'VersionId and IsCurrentVersion' are required if this property is set to true, else they must be excluded.
  - `[FilterIncludeSnapshot <Boolean?>]`: Includes blob snapshots in blob inventory when value is set to true. The definition.schemaFields value 'Snapshot' is required if this property is set to true, else it must be excluded.
  - `[FilterPrefixMatch <String[]>]`: An array of strings for blob prefixes to be matched.

PROPERTY <IBlobInventoryPolicy>: The storage account blob inventory policy.
  - `[PolicyEnabled <Boolean?>]`: Policy is enabled if set to true.
  - `[PolicyRule <IBlobInventoryPolicyRule[]>]`: The storage account blob inventory policy rules. The rule is applied when it is enabled.
    - `DefinitionFormat <Format>`: This is a required field, it specifies the format for the inventory files.
    - `DefinitionObjectType <ObjectType>`: This is a required field. This field specifies the scope of the inventory created either at the blob or container level.
    - `DefinitionSchedule <Schedule>`: This is a required field. This field is used to schedule an inventory formation.
    - `DefinitionSchemaField <String[]>`: This is a required field. This field specifies the fields and properties of the object to be included in the inventory. The Schema field value 'Name' is always required. The valid values for this field for the 'Blob' definition.objectType include 'Name, Creation-Time, Last-Modified, Content-Length, Content-MD5, BlobType, AccessTier, AccessTierChangeTime, AccessTierInferred, Tags, Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl, Snapshot, VersionId, IsCurrentVersion, Metadata, LastAccessTime'. The valid values for 'Container' definition.objectType include 'Name, Last-Modified, Metadata, LeaseStatus, LeaseState, LeaseDuration, PublicAccess, HasImmutabilityPolicy, HasLegalHold'. Schema field values 'Expiry-Time, hdi_isfolder, Owner, Group, Permissions, Acl' are valid only for Hns enabled accounts.'Tags' field is only valid for non Hns accounts
    - `Destination <String>`: Container name where blob inventory files are stored. Must be pre-created.
    - `Enabled <Boolean>`: Rule is enabled when set to true.
    - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
    - `[FilterBlobType <String[]>]`: An array of predefined enum values. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs. This field is required when definition.objectType property is set to 'Blob'.
    - `[FilterIncludeBlobVersion <Boolean?>]`: Includes blob versions in blob inventory when value is set to true. The definition.schemaFields values 'VersionId and IsCurrentVersion' are required if this property is set to true, else they must be excluded.
    - `[FilterIncludeSnapshot <Boolean?>]`: Includes blob snapshots in blob inventory when value is set to true. The definition.schemaFields value 'Snapshot' is required if this property is set to true, else it must be excluded.
    - `[FilterPrefixMatch <String[]>]`: An array of strings for blob prefixes to be matched.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

