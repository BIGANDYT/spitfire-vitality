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

cd /D %InstallerPath%\SIM
Hedgehog.Tds.Build.Sim.Console.exe delete "InstanceName:%SiteName%" "InstanceDirectory:%InstanceDirectory%" "ConnectionString:%DbConnectionString%"

cd /d %BuildDirectory%