@echo off
cd /d %0\..
call vars.cmd

:: Put back in but without Sitecore Ship
::echo Smart publish...
::tools\curl -X POST --data '' "http://%sitename%/sitecore_ship/publish/smart"
::IF "%ERRORLEVEL%" NEQ "0" (
::	echo Package installation failed
::	exit /B %ERRORLEVEL%
::)

exit /B 0