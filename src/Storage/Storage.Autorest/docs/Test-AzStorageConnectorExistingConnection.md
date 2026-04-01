---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/test-azstorageconnectorexistingconnection
schema: 2.0.0
---

# Test-AzStorageConnectorExistingConnection

## SYNOPSIS
This method is used to verify that the connection to the backing data store works.\nThis API is designed to be used for monitoring and debugging purposes.
From the caller’s perspective,\nthis method does the following: Calls List on the backing data store, attempting to list up to one blob/object/etc.\nIf the above succeeds, and if a blob/object/etc is found, calls Get on that object, attempting to download one byte.

## SYNTAX

### TestExpanded (Default)
```
Test-AzStorageConnectorExistingConnection -AccountName <String> -ConnectorName <String>
 -ResourceGroupName <String> -UniqueId <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Test
```
Test-AzStorageConnectorExistingConnection -AccountName <String> -ConnectorName <String>
 -ResourceGroupName <String> -Body <ITestExistingConnectionRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzStorageConnectorExistingConnection -InputObject <IStorageIdentity>
 -Body <ITestExistingConnectionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzStorageConnectorExistingConnection -InputObject <IStorageIdentity> -UniqueId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityStorageAccount
```
Test-AzStorageConnectorExistingConnection -ConnectorName <String>
 -StorageAccountInputObject <IStorageIdentity> -Body <ITestExistingConnectionRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityStorageAccountExpanded
```
Test-AzStorageConnectorExistingConnection -ConnectorName <String>
 -StorageAccountInputObject <IStorageIdentity> -UniqueId <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzStorageConnectorExistingConnection -AccountName <String> -ConnectorName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzStorageConnectorExistingConnection -AccountName <String> -ConnectorName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This method is used to verify that the connection to the backing data store works.\nThis API is designed to be used for monitoring and debugging purposes.
From the caller’s perspective,\nthis method does the following: Calls List on the backing data store, attempting to list up to one blob/object/etc.\nIf the above succeeds, and if a blob/object/etc is found, calls Get on that object, attempting to download one byte.

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

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: True
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

### -Body
Test existing connection request properties

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ITestExistingConnectionRequest
Parameter Sets: Test, TestViaIdentity, TestViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectorName
The name of the Storage Connector.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaIdentityStorageAccount, TestViaIdentityStorageAccountExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: TestViaIdentity, TestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonString
Aliases:

Required: True
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
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: TestViaIdentityStorageAccount, TestViaIdentityStorageAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UniqueId
The uniqueId of the storage connector as returned by the server.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded, TestViaIdentityStorageAccountExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ITestExistingConnectionRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ITestConnectionResponse

## NOTES

## RELATED LINKS

