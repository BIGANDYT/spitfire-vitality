@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln

if not exist ..\lib\Sitecore (
	mkdir ..\lib\Sitecore
	copy c:\websites\%SiteName%\Website\bin\Sitecore.*.dll ..\lib\Sitecore
)

SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%InstanceDirectory%\%sitename%\Website

IF NOT DEFINED IsBuildServer (
	del %InstanceDirectory%\%sitename%\Website\bin\Spitfire.*
	rd /s /q c:\websites\%sitename%\Website\App_Config\Include\zSpitfire
)

%msbuild% ..\src\Spitfire.Website\Spitfire.Website.csproj %DeployParameters%

IF DEFINED IsBuildServer (
	powershell -file build-FixDataFolder.ps1 "%InstanceDirectory%\%sitename%\Website\web.config" "%InstanceDirectory%\%sitename%\Data"
	powershell -file build-FixUnicornFolder.ps1 "%InstanceDirectory%\%sitename%\Website\App_Config\Include\Serialization.config" "%CD%"
)