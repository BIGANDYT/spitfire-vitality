@echo off
call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
chmod 600 tools\sitecoreci.key
tools\rsync -rtvn -e 'ssh -p 65422 -i tools/sitecoreci.key' spitfireinstaller@sitecoreci.cloudapp.net:/cygdrive/c/spitfireinstaller/ /cygdrive/c/spitfireinstaller/

pause
exit /B 1

IF /I NOT "%CD%" EQU "%SourceDirectory%\build" (
	echo This repository should be checked out to %SourceDirectory% - CD is %CD%
	pause
	EXIT /B 1
)

%appcmd% list site /name:"%BaseSite%"
IF "%ERRORLEVEL%" EQU "0" (
	echo Site %BaseSite% already installed
	pause
	EXIT /B 2
)

:: Install Sitecore using SIM
call sim.cmd %BaseSite%

:: Build the sucker
call build-all.cmd

:: Install updates using Sitecore Ship
call updates.cmd %BaseSite%

:: Deploying Unicorn items
call sync.cmd %BaseSite%

echo Installation finished
pause