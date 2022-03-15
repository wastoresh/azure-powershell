@{
  GUID = '1fc13c42-eb0c-4814-a5ad-cbc6a49b4269'
  RootModule = './Az.Storage.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: Storage cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.Storage.private.dll'
  FormatsToProcess = './Az.Storage.format.ps1xml'
  FunctionsToExport = 'Clear-AzStorageBlobContainerLegalHold', 'Get-AzStorageAccount', 'Get-AzStorageAccountKey', 'Get-AzStorageAccountProperty', 'Get-AzStorageAccountSas', 'Get-AzStorageAccountServiceSas', 'Get-AzStorageBlobContainer', 'Get-AzStorageBlobContainerImmutabilityPolicy', 'Get-AzStorageBlobInventoryPolicy', 'Get-AzStorageBlobService', 'Get-AzStorageBlobServiceProperty', 'Get-AzStorageDeletedAccount', 'Get-AzStorageEncryptionScope', 'Get-AzStorageFileService', 'Get-AzStorageFileServiceProperty', 'Get-AzStorageFileShare', 'Get-AzStorageLocalUser', 'Get-AzStorageLocalUserKey', 'Get-AzStorageManagementPolicy', 'Get-AzStorageObjectReplicationPolicy', 'Get-AzStoragePrivateEndpointConnection', 'Get-AzStoragePrivateLinkResource', 'Get-AzStorageSku', 'Get-AzStorageUsage', 'Invoke-AzStorageAbortStorageAccountHierarchicalNamespaceMigration', 'Invoke-AzStorageExtendBlobContainerImmutabilityPolicy', 'Invoke-AzStorageHierarchicalStorageAccountNamespaceMigration', 'Invoke-AzStorageLeaseBlobContainer', 'Invoke-AzStorageLeaseFileShare', 'Invoke-AzStorageObjectBlobContainerLevelWorm', 'Lock-AzStorageBlobContainerImmutabilityPolicy', 'New-AzStorageAccount', 'New-AzStorageAccountKey', 'New-AzStorageBlobContainer', 'New-AzStorageBlobContainerImmutabilityPolicy', 'New-AzStorageBlobInventoryPolicy', 'New-AzStorageFileShare', 'New-AzStorageLocalUser', 'New-AzStorageLocalUserPassword', 'New-AzStorageManagementPolicy', 'New-AzStorageObjectReplicationPolicy', 'New-AzStorageVirtualNetworkRuleObject', 'Remove-AzStorageAccount', 'Remove-AzStorageBlobContainer', 'Remove-AzStorageBlobContainerImmutabilityPolicy', 'Remove-AzStorageBlobInventoryPolicy', 'Remove-AzStorageFileShare', 'Remove-AzStorageLocalUser', 'Remove-AzStorageManagementPolicy', 'Remove-AzStorageObjectReplicationPolicy', 'Remove-AzStoragePrivateEndpointConnection', 'Restore-AzStorageAccountBlobRange', 'Restore-AzStorageFileShare', 'Revoke-AzStorageAccountUserDelegationKey', 'Set-AzStorageAccount', 'Set-AzStorageBlobContainerImmutabilityPolicy', 'Set-AzStorageBlobContainerLegalHold', 'Set-AzStorageBlobInventoryPolicy', 'Set-AzStorageBlobServiceProperty', 'Set-AzStorageEncryptionScope', 'Set-AzStorageFileServiceProperty', 'Set-AzStorageLocalUser', 'Set-AzStorageManagementPolicy', 'Set-AzStorageObjectReplicationPolicy', 'Set-AzStoragePrivateEndpointConnection', 'Test-AzStorageAccountNameAvailability', 'Update-AzStorageAccount', 'Update-AzStorageBlobContainer', 'Update-AzStorageEncryptionScope', 'Update-AzStorageFileShare', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'Storage'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
