@echo off
call vars.cmd

cd /D %InstallerPath%\SIM
Hedgehog.Tds.Build.Sim.Console.exe export "InstanceName:%BaseSite%" "ExportFilePath:c:\websites\spitfire.zip"
cd %BuildDirectory%

pause