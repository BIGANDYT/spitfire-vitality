@echo off
cd /d %0\..

IF NOT DEFINED IsBuildServer (
	:: Checking for administrator permissions...
	openfiles 1>nul 2>&1
	if not %errorlevel% equ 0 (
		echo Please run this script as an administrator
		EXIT /B 1
	)
)

>nul powershell.exe -executionpolicy unrestricted -command set-executionpolicy unrestricted
call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
IF NOT DEFINED IsBuildServer call sync-installer.cmd

%appcmd% list site /name:"%SiteName%"
IF "%ERRORLEVEL%" EQU "0" (
	IF DEFINED IsBuildServer (
		call delete.cmd
		IF "%ERRORLEVEL%" NEQ "0" (
			echo SIM delete failed
			exit /B %ERRORLEVEL%
		)
	) else (
		echo Site %SiteName% already installed
		EXIT /B 2	
	)
)

:: Install Sitecore using SIM
call sim.cmd
IF "%ERRORLEVEL%" NEQ "0" (
	echo SIM install failed
	exit /B %ERRORLEVEL%
)

call fix-file-permissions.cmd

:: Add extra hostnames to IIS and c:\windows\system32\drivers\etc\hosts file
powershell -file add-extra-hosts.ps1
IF "%ERRORLEVEL%" NEQ "0" (
	echo Adding extra hosts failed
	exit /B %ERRORLEVEL%
)

:: Build the sucker
call build.cmd
IF "%ERRORLEVEL%" NEQ "0" (
	echo Build failed
	exit /B %ERRORLEVEL%
)

:: Install updates using Sitecore Ship
call updates.cmd
IF "%ERRORLEVEL%" NEQ "0" (
	echo Installing packages failed
	exit /B %ERRORLEVEL%
)

:: Deploying Unicorn items
call sync.cmd
IF "%ERRORLEVEL%" NEQ "0" (
	echo Deploying Unicorn failed
	exit /B %ERRORLEVEL%
)

ren %InstanceDirectory%\%sitename%\Website\App_Config\Include\Serialization.config Serialization.config.bak

:: Rebuild link databases
echo Rebuilding link databases...
tools\curl -f "http://%sitename%/handlers/build/RebuildLinkDatabases.ashx"
IF "%ERRORLEVEL%" NEQ "0" (
	echo Rebuilding link databases failed
	exit /B %ERRORLEVEL%
)

:: Deploy marketing assets - Disabled for now until we fix bug 438833
::echo Deploying marketing assets...
::tools\curl -f "http://%sitename%/handlers/build/DeployMarketingAssets.ashx"
::IF "%ERRORLEVEL%" NEQ "0" (
::	echo Deploying marketing assets failed
::	exit /B %ERRORLEVEL%
::)

:: Remove the hack of disabling indexing during install
del %InstanceDirectory%\%sitename%\Website\App_Config\Include\zSpitfire\DisableIndexing.config

:: Rebuild search indexes
echo Rebuilding system search index...
tools\curl -f "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=system"
IF "%ERRORLEVEL%" NEQ "0" (
	echo Rebuild system index failed
	exit /B %ERRORLEVEL%
)

echo Rebuilding sitecore_core_index search index...
tools\curl -f "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=sitecore_core_index"
IF "%ERRORLEVEL%" NEQ "0" (
	echo Rebuild core search index failed
	exit /B %ERRORLEVEL%
)

echo Rebuilding sitecore_master_index search index...
tools\curl -f "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=sitecore_master_index"
IF "%ERRORLEVEL%" NEQ "0" (
	echo Rebuild master search index failed
	exit /B %ERRORLEVEL%
)

:: Smart publish
call publish.cmd
IF "%ERRORLEVEL%" NEQ "0" (
	echo Smart published failed
	exit /B %ERRORLEVEL%
)

:: Remove Unicorn serialization in preparation for zipping on the build server
IF DEFINED IsBuildServer (
	del %InstanceDirectory%\%sitename%\Website\App_Config\Include\Serialization.config.bak
) else (
	ren %InstanceDirectory%\%sitename%\Website\App_Config\Include\Serialization.config.bak Serialization.config
)

echo Installation finished
exit /B 0