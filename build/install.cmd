@echo off
cd /d %0\..

:: Checking for administrator permissions...
openfiles 1>nul 2>&1
if not %errorlevel% equ 0 (
    echo Please run this script as an administrator
	pause
	EXIT /B 1
)

call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
IF NOT DEFINED IsBuildServer call sync-installer.cmd

IF NOT DEFINED IsBuildServer (
	IF /I NOT "%CD%" EQU "%SourceDirectory%\build" (
		echo This repository should be checked out to %SourceDirectory% - CD is %CD%
		pause
		EXIT /B 2
	)
)

%appcmd% list site /name:"%SiteName%"
IF "%ERRORLEVEL%" EQU "0" (
	IF DEFINED IsBuildServer (
		call delete.cmd
	) else (
		echo Site %SiteName% already installed
		pause
		EXIT /B 3	
	)
)

:: Install Sitecore using SIM
call sim.cmd

:: Build the sucker
call build.cmd

:: Install updates using Sitecore Ship
call updates.cmd

:: Deploying Unicorn items
call sync.cmd

echo Installation finished
pause