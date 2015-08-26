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

%msbuild% ..\src\Framework\Assets\Spitfire.Framework.Assets.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Framework.Assets project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Framework\BuildProcess\Spitfire.Framework.BuildProcess.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Framework.BuildProcess project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Framework\Health\Spitfire.Framework.Health.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Framework.Health project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Framework\SitecoreExtensions\Spitfire.Framework.SitecoreExtensions.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Framework.SitecoreExtensions project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\CRM\Spitfire.CRM.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.CRM project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\Identity\Spitfire.Identity.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.Identity project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\Metadata\Spitfire.Metadata.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.Metadata project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\Navigation\Spitfire.Navigation.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.Navigation project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\News\Spitfire.News.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.News project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\Social\Spitfire.Social.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.Social project failed
	exit /B %ERRORLEVEL%
)

%msbuild% ..\src\Domain\StandardContent\Spitfire.StandardContent.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Domain.StandardContent project failed
	exit /B %ERRORLEVEL%
)

SET DevSettings=%SourceDirectory%\src\Website\App_Config\Include\Spitfire.DevSettings.config
IF NOT EXIST %DevSettings% (
	copy %DevSettings%.sample %DevSettings%
	powershell -file build-FixDataFolder.ps1 "%DevSettings%" "%InstanceDirectory%\%sitename%\Data"
	powershell -file build-FixUnicornFolder.ps1 "%DevSettings%" "%CD%"

	IF "%ERRORLEVEL%" NEQ "0" (
		echo Powershell updates failed
		exit /B %ERRORLEVEL%
	)
)

%msbuild% ..\src\Website\Spitfire.Website.csproj %DeployParameters%
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build of Website project failed
	exit /B %ERRORLEVEL%
)

IF DEFINED IsBuildServer (
	powershell -file build-FixDataFolder.ps1 "%WebsiteDirectory%\Web.config" "%InstanceDirectory%\%sitename%\Data"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Powershell updates failed
		exit /B %ERRORLEVEL%
	)
)

exit /B 0