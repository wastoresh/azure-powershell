@{
  GUID = 'fe6bec3f-ba73-47e3-ab1f-884f1dea4317'
  RootModule = './Az.DataMover.psm1'
  ModuleVersion = '0.1.0'
  CompatiblePSEditions = 'Core', 'Desktop'
  Author = 'Microsoft Corporation'
  CompanyName = 'Microsoft Corporation'
  Copyright = 'Microsoft Corporation. All rights reserved.'
  Description = 'Microsoft Azure PowerShell: DataMover cmdlets'
  PowerShellVersion = '5.1'
  DotNetFrameworkVersion = '4.7.2'
  RequiredAssemblies = './bin/Az.DataMover.private.dll'
  FormatsToProcess = './Az.DataMover.format.ps1xml'
  FunctionsToExport = 'Get-AzDataMover', 'Get-AzDataMoverAgent', 'Get-AzDataMoverEndpoint', 'Get-AzDataMoverJobDefinition', 'Get-AzDataMoverJobRun', 'Get-AzDataMoverProject', 'New-AzDataMover', 'New-AzDataMoverAgent', 'New-AzDataMoverAzureStorageBlobContainerEndpointPropertiesObject', 'New-AzDataMoverAzureStorageBlobContainerEndpointUpdatePropertiesObject', 'New-AzDataMoverEndpoint', 'New-AzDataMoverJobDefinition', 'New-AzDataMoverNfsMountEndpointPropertiesObject', 'New-AzDataMoverNfsMountEndpointUpdatePropertiesObject', 'New-AzDataMoverProject', 'Remove-AzDataMover', 'Remove-AzDataMoverAgent', 'Remove-AzDataMoverEndpoint', 'Remove-AzDataMoverJobDefinition', 'Remove-AzDataMoverProject', 'Start-AzDataMoverJob', 'Stop-AzDataMoverJob', 'Update-AzDataMover', 'Update-AzDataMoverAgent', 'Update-AzDataMoverEndpoint', 'Update-AzDataMoverJobDefinition', 'Update-AzDataMoverProject', '*'
  AliasesToExport = '*'
  PrivateData = @{
    PSData = @{
      Tags = 'Azure', 'ResourceManager', 'ARM', 'PSModule', 'DataMover'
      LicenseUri = 'https://aka.ms/azps-license'
      ProjectUri = 'https://github.com/Azure/azure-powershell'
      ReleaseNotes = ''
    }
  }
}
