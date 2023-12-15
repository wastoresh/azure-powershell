<!-- region Generated -->
# Az.StorageAction
This directory contains the PowerShell module for the StorageAction service.

---
## Status
[![Az.StorageAction](https://img.shields.io/powershellgallery/v/Az.StorageAction.svg?style=flat-square&label=Az.StorageAction "Az.StorageAction")](https://www.powershellgallery.com/packages/Az.StorageAction/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.StorageAction`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Please specify the commit id that includes your features to make sure generated codes stable.
branch: 13f09225c7d1cf42c55536e41c090bb8438cebd7
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/storageactions/resource-manager/Microsoft.StorageActions/stable/2023-01-01/storageactions.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: StorageAction
subject-prefix: $(service-name)
nested-object-to-string: true
identity-correction-for-post: true 
use-extension: 
  "@autorest/powershell": "4.x"

directive:
  #- where:
  #    verb: Invoke
  #    subject: PreviewStorageTaskAction
  #  set:
  #    verb: Invoke
  #    subject: StorageTaskPreviewAction
  - model-cmdlet:
      - model-name: StorageTaskOperation
  - model-cmdlet:
      - model-name: StorageTaskPreviewBlobProperties
  - model-cmdlet:
      - model-name: StorageTaskPreviewKeyValueProperties		
```
