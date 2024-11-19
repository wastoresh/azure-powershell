# Before running the tests:
1. Create a directory called "data" under directory "RegressionTests" and create files with following names and sizes:
	| File Name          | Size    |
	|--------------------|---------|
	| testfile_1K_0      | 1KB     |
	| testfile_10M       | 10M     |
	| testfile_300M      | 300M    |
	| testfile_2048K     | 2048K   |
	| testfile_10240K_0  | 10240K  |
	| testfile_300000K_0 | 300000K |

2. Create a directoy called "created" under directory "RegressionTests"
3. Fill in the placeholders in config_template.xml and change its name to config.xml 

# To run the tests line by line:

1. If using local builds of the modules, import Az.Accounts and Az.Storage with the following commands:
	Import-Module {path to azure-powershell}\azure-powershell\artifacts\Debug\Az.Accounts\Az.Accounts.psd1 
	Import-Module {path to azure-powershell}\azure-powershell\artifacts\Debug\Az.Storage\Az.Storage.psd1 
2. cd to {path to auzre-powershell repo}\azure-powershell\src\Storage\RegressionTests 
