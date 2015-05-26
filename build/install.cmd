@echo off
call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
bash -c "chmod 600 tools/sitecoreci.key"
bash -c "tools/rsync --delete -rtv -e 'ssh -p 65422 -i tools/sitecoreci.key' spitfireinstaller@sitecoreci.cloudapp.net:/cygdrive/c/spitfireinstaller/ /cygdrive/c/spitfireinstaller/"

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