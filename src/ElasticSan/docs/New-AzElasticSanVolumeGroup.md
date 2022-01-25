---
external help file:
Module Name: Az.ElasticSan
online version: https://docs.microsoft.com/powershell/module/az.elasticsan/new-azelasticsanvolumegroup
schema: 2.0.0
---

# New-AzElasticSanVolumeGroup

## SYNOPSIS
Create or Update a Volume Group.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -Subnet <String> [-SubscriptionId <String>] [-NetworkAclsDefaultAction <NetworkRuleAction>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzElasticSanVolumeGroup -ElasticSanName <String> -Name <String> -ResourceGroupName <String>
 -VolumeGroupCreate <IVolumeGroupCreate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> -VolumeGroupCreate <IVolumeGroupCreate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzElasticSanVolumeGroup -InputObject <IElasticSanIdentity> -Subnet <String>
 [-NetworkAclsDefaultAction <NetworkRuleAction>] [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or Update a Volume Group.

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
Parameter Sets: Create, CreateExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.IElasticSanIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases: VolumeGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsDefaultAction
The default action when no rule from ipRules and from virtualNetworkRules match.
This is only used after the bypass property has been evaluated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Support.NetworkRuleAction
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -ResourceGroupName
The name of the resource group.
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

### -Subnet
Volume Group subnet id.

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

### -VolumeGroupCreate
Payload for VolumeGroup create or update requests.
To construct, see NOTES section for VOLUMEGROUPCREATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolumeGroupCreate
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.ElasticSan.Models.Api20211120Preview.IVolumeGroupCreate

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
  - `[SnapshotName <String>]`: The name of the Volume Snapshot.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VolumeGroupName <String>]`: The name of the VolumeGroup.
  - `[VolumeName <String>]`: The name of the Volume.

NETWORKACLSVIRTUALNETWORKRULE <IVirtualNetworkRule[]>: The list of virtual network rules.
  - `Id <String>`: Full resource id of a vnet subnet, such as '/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1'.
  - `[IgnoreMissingVnetServiceEndpoint <Boolean?>]`: Ignore missing vnet service endpoint or not.
  - `[State <String>]`: Gets the state of virtual network rule.
  - `[Subnet <String[]>]`: The list of subnets.

VOLUMEGROUPCREATE <IVolumeGroupCreate>: Payload for VolumeGroup create or update requests.
  - `Subnet <String>`: Volume Group subnet id.
  - `[Encryption <EncryptionType?>]`: Type of encryption
  - `[NetworkAclsDefaultAction <NetworkRuleAction?>]`: The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated.
  - `[NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>]`: The list of virtual network rules.
    - `Id <String>`: Full resource id of a vnet subnet, such as '/subscriptions/subid/resourceGroups/rg1/providers/Microsoft.Network/virtualNetworks/test-vnet/subnets/subnet1'.
    - `[IgnoreMissingVnetServiceEndpoint <Boolean?>]`: Ignore missing vnet service endpoint or not.
    - `[State <String>]`: Gets the state of virtual network rule.
    - `[Subnet <String[]>]`: The list of subnets.
  - `[ProtocolType <StorageTargetType?>]`: Type of storage target

## RELATED LINKS

