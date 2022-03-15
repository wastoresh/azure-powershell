---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.Storage/new-AzStorageVirtualNetworkRuleObject
schema: 2.0.0
---

# New-AzStorageVirtualNetworkRuleObject

## SYNOPSIS
Create an in-memory object for VirtualNetworkRule.

## SYNTAX

```
New-AzStorageVirtualNetworkRuleObject -VirtualNetworkResourceId <String> [-Action <Action>] [-State <State>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualNetworkRule.

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

### -Action
The action of virtual network rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Action
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Gets the state of virtual network rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.State
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkResourceId
Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.VirtualNetworkRule

## NOTES

ALIASES

## RELATED LINKS

