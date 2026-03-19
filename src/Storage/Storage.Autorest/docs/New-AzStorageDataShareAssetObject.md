---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/Az.Storage/new-azstoragedatashareassetobject
schema: 2.0.0
---

# New-AzStorageDataShareAssetObject

## SYNOPSIS
Create an in-memory object for StorageDataShareAsset.

## SYNTAX

```
New-AzStorageDataShareAssetObject -AssetPath <String> -DisplayName <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageDataShareAsset.

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

### -AssetPath
Source Path to be shared.
It can be a folder or a blob.
        The asset path should contain container name followed by path within the container, e.g.
/container1/logs/external.

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

### -DisplayName
Consumer visible name of the original path.

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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.StorageDataShareAsset

## NOTES

## RELATED LINKS

