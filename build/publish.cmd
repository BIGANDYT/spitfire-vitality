@echo off
cd /d %0\..
call vars.cmd

echo Smart publish...
tools\curl -X POST --data '' "http://%sitename%/sitecore_ship/publish/smart"