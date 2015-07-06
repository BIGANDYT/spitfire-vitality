@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln

if not exist ..\lib\Sitecore (
	mkdir ..\lib\Sitecore
	copy c:\websites\%SiteName%\Website\bin\Sitecore.*.dll ..\lib\Sitecore
)

if not exist ..\lib\System (
	mkdir ..\lib\System
	copy c:\websites\%SiteName%\Website\bin\System.*.dll ..\lib\System
)

SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%InstanceDirectory%\%sitename%\Website

%msbuild% ..\src\Spitfire.Website\Spitfire.Website.csproj %DeployParameters%

SET DevSettings=%InstanceDirectory%\%sitename%\Website\App_Config\Include\zSpitfire\DevSettings.config
IF NOT EXIST %DevSettings% (
	copy %DevSettings%.sample %DevSettings%
	powershell -file build-FixDataFolder.ps1 "%DevSettings%" "%InstanceDirectory%\%sitename%\Data"
	powershell -file build-FixUnicornFolder.ps1 "%DevSettings%" "%CD%"
)