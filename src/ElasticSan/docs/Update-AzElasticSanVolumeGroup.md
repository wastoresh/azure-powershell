---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/update-azelasticsanvolumegroup
schema: 2.0.0
---

# Update-AzElasticSanVolumeGroup

## SYNOPSIS
Update an VolumeGroup.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Encryption <EncryptionType>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <StorageTargetType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -Parameter <IVolumeGroupUpdate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> -Parameter <IVolumeGroupUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> [-Encryption <EncryptionType>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-ProtocolType <StorageTargetType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an VolumeGroup.

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

### -ElasticSanName
The name of the ElasticSan.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Encryption
Type of encryption

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Support.EncryptionType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the VolumeGroup.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: VolumeGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsVirtualNetworkRule
The list of virtual network rules.
To construct, see NOTES section for NETWORKACLSVIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVirtualNetworkRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Volume Group request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolumeGroupUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtocolType
Type of storage target

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Support.StorageTargetType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolumeGroupUpdate

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolumeGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IElasticSanIdentity>: Identity Parameter
  - `[ElasticSanName <String>]`: The name of the ElasticSan.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SnapshotName <String>]`: The name of the snapshot within the given subscription, resource and volume group.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VolumeGroupName <String>]`: The name of the VolumeGroup.
  - `[VolumeName <String>]`: The name of the Volume.

NETWORKACLSVIRTUALNETWORKRULE <IVirtualNetworkRule[]>: The list of virtual network rules.
  - `VirtualNetworkResourceId <String>`: Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
  - `[Action <Action?>]`: The action of virtual network rule.

PARAMETER <IVolumeGroupUpdate>: Volume Group request.
  - `[Encryption <EncryptionType?>]`: Type of encryption
  - `[NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]`: The list of virtual network rules.
    - `VirtualNetworkResourceId <String>`: Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
    - `[Action <Action?>]`: The action of virtual network rule.
  - `[ProtocolType <StorageTargetType?>]`: Type of storage target
  - `[Tag <IVolumeGroupUpdateTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

