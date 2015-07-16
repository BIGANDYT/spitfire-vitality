@echo off
cd /d %0\..
call vars.cmd

cd %InstanceDirectory%\%sitename%

echo Resetting file permissions
icacls * /reset /T

cd %BuildDirectory%