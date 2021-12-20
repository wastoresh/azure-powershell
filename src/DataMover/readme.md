<!-- region Generated -->
# Az.DataMover
This directory contains the PowerShell module for the DataMover service.

---
## Status
[![Az.DataMover](https://img.shields.io/powershellgallery/v/Az.DataMover.svg?style=flat-square&label=Az.DataMover "Az.DataMover")](https://www.powershellgallery.com/packages/Az.DataMover/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataMover`, see [how-to.md](how-to.md).
<!-- endregion -->

## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
# - https://github.com/golddove/azure-rest-api-specs-pr/blob/dev-datamover-Microsoft.Storage-2021-10-01-privatepreview/specification/datamover/resource-manager/Microsoft.Storage/preview/2021-08-01/datamover.json
 - C:\code\swagger\specification\datamover\resource-manager\Microsoft.Storage\preview\2021-08-01\datamover.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: DataMover
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  - where:
      model-name: Endpoint
    set:
      suppress-format: true	  
  - no-inline:
      - EndpointBaseProperties
  - model-cmdlet:
      - NfsMountEndpointProperties
      - AzureStorageBlobContainerEndpointProperties
  - no-inline:
      - EndpointBaseUpdateProperties
  - model-cmdlet:
      - NfsMountEndpointUpdateProperties
      - AzureStorageBlobContainerEndpointUpdateProperties
  # Rename Start-AzDataMoverJobDefinitionJob -> Start-AzDataMoverJob 
  - where:
      verb: Start
      subject: JobDefinitionJob
    set:
      verb: Start
      subject: Job
  # Rename Stop-AzDataMoverJobDefinitionJob -> Stop-AzDataMoverJob 
  - where:
      verb: Stop
      subject: JobDefinitionJob
    set:
      verb: Stop
      subject: Job	  
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      model-name: DataMover
    set:
      format-table:
        properties:
          - Name
          - Location
          - Description
```
