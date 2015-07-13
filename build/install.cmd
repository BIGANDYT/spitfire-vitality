@echo off
cd /d %0\..
>nul powershell.exe -executionpolicy unrestricted -command set-executionpolicy unrestricted

IF NOT DEFINED IsBuildServer (
	:: Checking for administrator permissions...
	openfiles 1>nul 2>&1
	if not %errorlevel% equ 0 (
		echo Please run this script as an administrator
		pause
		EXIT /B 1
	)
)

call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
IF NOT DEFINED IsBuildServer call sync-installer.cmd

%appcmd% list site /name:"%SiteName%"
IF "%ERRORLEVEL%" EQU "0" (
	IF DEFINED IsBuildServer (
		call delete.cmd
	) else (
		echo Site %SiteName% already installed
		pause
		EXIT /B 2	
	)
)

:: Install Sitecore using SIM
call sim.cmd

:: Add extra hostnames to IIS and c:\windows\system32\drivers\etc\hosts file
powershell -file add-extra-hosts.ps1

:: Build the sucker
call build.cmd

:: Install updates using Sitecore Ship
call updates.cmd

:: Deploying Unicorn items
call sync.cmd

:: Rebuild link databases
tools\curl "http://%sitename%/handlers/build/RebuildLinkDatabases.ashx"

:: Deploy marketing assets
tools\curl "http://%sitename%/handlers/build/DeployMarketingAssets.ashx"

:: Remove the hack of disabling indexing during install
del %InstanceDirectory%\%sitename%\Website\App_Config\Include\zSpitfire\DisableIndexing.config

:: Rebuild search indexes
tools\curl "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=system"
tools\curl "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=sitecore_core_index"
tools\curl "http://%sitename%/handlers/build/RebuildSearchIndexes.ashx?index=sitecore_master_index"

:: Smart publish
call publish.cmd

:: Remove Unicorn serialization in preparation for zipping on the build server
IF DEFINED IsBuildServer (
	del %InstanceDirectory%\%sitename%\Website\App_Config\Include\Serialization.config	
)

echo Installation finished
pause