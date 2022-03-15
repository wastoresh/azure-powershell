---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/new-azstorageobjectreplicationpolicy
schema: 2.0.0
---

# New-AzStorageObjectReplicationPolicy

## SYNOPSIS
Create or update the object replication policy of the storage account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageObjectReplicationPolicy -AccountName <String> -Id <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DestinationAccount <String>] [-Rule <IObjectReplicationPolicyRule[]>]
 [-SourceAccount <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzStorageObjectReplicationPolicy -AccountName <String> -Id <String> -ResourceGroupName <String>
 -Property <IObjectReplicationPolicy> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageObjectReplicationPolicy -InputObject <IStorageIdentity> -Property <IObjectReplicationPolicy>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageObjectReplicationPolicy -InputObject <IStorageIdentity> [-DestinationAccount <String>]
 [-Rule <IObjectReplicationPolicyRule[]>] [-SourceAccount <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update the object replication policy of the storage account.

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

### -DestinationAccount
Required.
Destination account name.
It should be full resource id if allowCrossTenantReplication set to false.

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

### -Id
For the destination account, provide the value 'default'.
Configure the policy on the destination account first.
For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account.
The policy is downloaded as a JSON file.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: ObjectReplicationPolicyId

Required: True
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

### -Property
The replication policy between two storage accounts.
Multiple rules can be defined in one policy.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IObjectReplicationPolicy
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

### -Rule
The storage account object replication rules.
To construct, see NOTES section for RULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IObjectReplicationPolicyRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAccount
Required.
Source account name.
It should be full resource id if allowCrossTenantReplication set to false.

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IObjectReplicationPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IObjectReplicationPolicy

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

PROPERTY <IObjectReplicationPolicy>: The replication policy between two storage accounts. Multiple rules can be defined in one policy.
  - `[DestinationAccount <String>]`: Required. Destination account name. It should be full resource id if allowCrossTenantReplication set to false.
  - `[Rule <IObjectReplicationPolicyRule[]>]`: The storage account object replication rules.
    - `DestinationContainer <String>`: Required. Destination container name.
    - `SourceContainer <String>`: Required. Source container name.
    - `[FilterMinCreationTime <String>]`: Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z
    - `[FilterPrefixMatch <String[]>]`: Optional. Filters the results to replicate only blobs whose names begin with the specified prefix.
    - `[RuleId <String>]`: Rule Id is auto-generated for each new rule on destination account. It is required for put policy on source account.
  - `[SourceAccount <String>]`: Required. Source account name. It should be full resource id if allowCrossTenantReplication set to false.

RULE <IObjectReplicationPolicyRule[]>: The storage account object replication rules.
  - `DestinationContainer <String>`: Required. Destination container name.
  - `SourceContainer <String>`: Required. Source container name.
  - `[FilterMinCreationTime <String>]`: Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z
  - `[FilterPrefixMatch <String[]>]`: Optional. Filters the results to replicate only blobs whose names begin with the specified prefix.
  - `[RuleId <String>]`: Rule Id is auto-generated for each new rule on destination account. It is required for put policy on source account.

## RELATED LINKS

