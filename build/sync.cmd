@echo off
cd /d %0\..

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

echo Deploying Unicorn items

tools\curl -H "Authenticate: 0af795cd-123e-40d7-9ee4-90dda0665a7c" "http://%sitename%/unicorn.aspx?verb=Sync&configuration=Default+Configuration"

:: Publish
tools\curl -X POST --data '' "http://%sitename%/sitecore_ship/publish/smart"

:End1