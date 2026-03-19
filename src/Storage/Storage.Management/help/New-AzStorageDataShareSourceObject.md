---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/Az.Storage/new-azstoragedatasharesourceobject
schema: 2.0.0
---

# New-AzStorageDataShareSourceObject

## SYNOPSIS
Create an in-memory object for DataShareSource.

## SYNTAX

```
New-AzStorageDataShareSourceObject -AuthProperty <IStorageConnectorAuthProperties>
 [-Connection <IStorageConnectorConnection>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataShareSource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AuthProperty
Details for how to authenticate to the backing data store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageConnectorAuthProperties
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
Details for how to connect to the backing data store.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageConnectorConnection
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.DataShareSource

## NOTES

## RELATED LINKS
