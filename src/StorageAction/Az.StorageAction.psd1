@{
  GUID = 'db7a46ee-cc81-40e9-87a6-67bfb2985ff5'
  RootModule = './Az.StorageAction.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: StorageAction cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.StorageAction.private.dll'
  FormatsToProcess = './Az.StorageAction.format.ps1xml'
  FunctionsToExport = 'Get-AzStorageActionStorageTask', 'Get-AzStorageActionStorageTaskAssignment', 'Get-AzStorageActionStorageTasksReport', 'Invoke-AzStorageActionPreviewStorageTaskAction', 'New-AzStorageActionStorageTask', 'New-AzStorageActionStorageTaskOperationObject', 'New-AzStorageActionStorageTaskPreviewBlobPropertiesObject', 'New-AzStorageActionStorageTaskPreviewKeyValuePropertiesObject', 'Remove-AzStorageActionStorageTask', 'Update-AzStorageActionStorageTask'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'StorageAction'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
