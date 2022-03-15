---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/set-azstorageencryptionscope
schema: 2.0.0
---

# Set-AzStorageEncryptionScope

## SYNOPSIS
Synchronously creates or updates an encryption scope under the specified storage account.
If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request.

## SYNTAX

### PutExpanded (Default)
```
Set-AzStorageEncryptionScope -AccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EncryptionScopePropertyRequireInfrastructureEncryption]
 [-EncryptionScopePropertySource <EncryptionScopeSource>]
 [-EncryptionScopePropertyState <EncryptionScopeState>] [-KeyVaultPropertyKeyUri <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Put
```
Set-AzStorageEncryptionScope -AccountName <String> -Name <String> -ResourceGroupName <String>
 -EncryptionScope <IEncryptionScope> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Synchronously creates or updates an encryption scope under the specified storage account.
If an encryption scope is already created and a subsequent request is issued with different properties, the encryption scope properties will be updated per the specified request.

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
Parameter Sets: (All)
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

### -EncryptionScope
The Encryption Scope resource.
To construct, see NOTES section for ENCRYPTIONSCOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IEncryptionScope
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EncryptionScopePropertyRequireInfrastructureEncryption
A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionScopePropertySource
The provider for the encryption scope.
Possible values (case-insensitive): Microsoft.Storage, Microsoft.KeyVault.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.EncryptionScopeSource
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionScopePropertyState
The state of the encryption scope.
Possible values (case-insensitive): Enabled, Disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.EncryptionScopeState
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPropertyKeyUri
The object identifier for a key vault key object.
When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope.

```yaml
Type: System.String
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the encryption scope within the specified storage account.
Encryption scope names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only.
Every dash (-) character must be immediately preceded and followed by a letter or number.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EncryptionScopeName

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IEncryptionScope

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210801.IEncryptionScope

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ENCRYPTIONSCOPE <IEncryptionScope>: The Encryption Scope resource.
  - `[KeyVaultPropertyKeyUri <String>]`: The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope.
  - `[PropertyRequireInfrastructureEncryption <Boolean?>]`: A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
  - `[PropertySource <EncryptionScopeSource?>]`: The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault.
  - `[PropertyState <EncryptionScopeState?>]`: The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled.

## RELATED LINKS

