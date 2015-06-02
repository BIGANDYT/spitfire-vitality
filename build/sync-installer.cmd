@echo off
cd /d %0\..

call vars.cmd

tools\bash -c "tools/chmod 600 tools/sitecoreci.key"
tools\bash -c "tools/rsync --delete -zrtv -e 'tools\ssh -p 65422 -i tools/sitecoreci.key -o UserKnownHostsFile=./known_hosts' spitfireinstaller@sitecoreci.cloudapp.net:/cygdrive/c/spitfireinstaller/ /cygdrive/c/spitfireinstaller/"