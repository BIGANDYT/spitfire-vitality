@echo off
cd /d %0\..

call vars.cmd

cd /D %InstallerPath%\SIM
Hedgehog.Tds.Build.Sim.Console.exe delete "InstanceName:%BaseSite%" "InstanceDirectory:%InstanceDirectory%" "ConnectionString:%DbConnectionString%"

cd /d %BuildDirectory%