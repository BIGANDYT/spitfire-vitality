@echo off
call vars.cmd

tools\bash -c "tools/rsync --delete -zrtv -e 'tools\ssh -p 65422 -i tools/sitecoreci.key' spitfireinstaller@sitecoreci.cloudapp.net:/cygdrive/c/spitfireinstaller/ /cygdrive/c/spitfireinstaller/"