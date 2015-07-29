@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln
IF "%ERRORLEVEL%" NEQ "0" (
	echo Nuget Restore failed
	exit /B %ERRORLEVEL%
)

SET WebsiteDirectory=%InstanceDirectory%\%sitename%\Website

if not exist ..\lib\Sitecore (
	mkdir ..\lib\Sitecore
	copy %WebsiteDirectory%\bin\Sitecore.*.dll ..\lib\Sitecore

	IF "%ERRORLEVEL%" NEQ "0" (
		echo Copying Sitecore libs failed
		exit /B %ERRORLEVEL%
	)
)

if not exist ..\lib\System (
	mkdir ..\lib\System
	copy %WebsiteDirectory%\bin\System.*.dll ..\lib\System

	IF "%ERRORLEVEL%" NEQ "0" (
		echo Copying System libs failed
		exit /B %ERRORLEVEL%
	)
)

SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%WebsiteDirectory%

%msbuild% ..\src\Spitfire.Website\Spitfire.Website.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Website project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Spitfire.Website\Spitfire.Website.Static.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Website static project failed
	exit /B %ERRORLEVEL%
)

SET DevSettings=%InstanceDirectory%\%sitename%\Website\App_Config\Include\zSpitfire\DevSettings.config
IF NOT EXIST %DevSettings% (
	copy %DevSettings%.sample %DevSettings%
	powershell -file build-FixDataFolder.ps1 "%DevSettings%" "%InstanceDirectory%\%sitename%\Data"
	powershell -file build-FixUnicornFolder.ps1 "%DevSettings%" "%CD%"

	IF "%ERRORLEVEL%" NEQ "0" (
		echo Powershell updates failed
		exit /B %ERRORLEVEL%
	)
)

IF DEFINED IsBuildServer (
	powershell -file build-FixDataFolder.ps1 "%WebsiteDirectory%\Web.config" "%InstanceDirectory%\%sitename%\Data"
)

exit /B 0