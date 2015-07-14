@echo off
cd /d %0\..
call vars.cmd

echo Deploying Unicorn items...
tools\curl -f -H "Authenticate: 0af795cd-123e-40d7-9ee4-90dda0665a7c" "http://%sitename%/unicorn.aspx?verb=Sync&configuration=Default+Configuration"