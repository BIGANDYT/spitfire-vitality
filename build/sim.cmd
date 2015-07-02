@echo off
cd /d %0\..
call vars.cmd

echo Installing %sitename% using SIM...
cd /D %InstallerPath%\SIM
Spitfire.Sim.Console.exe install "InstanceName:%sitename%" "InstanceDirectory:%InstanceDirectory%" "RepoDirectory:%InstallerPath%" "RepoFile:%SitecoreInstallName%" "ConnectionString:%DbConnectionString%" "AppPoolIdentity:NetworkService" "LicencePath:%InstallerPath%\license.xml" "Modules:Spitfire PostInstall 1.0 rev. 000000.zip|Web Forms for Marketers 8.0 rev. 150625.zip|Email Experience Manager 3.0 rev. 150429.zip|Microsoft Dynamics CRM Security Provider 2.1 rev. 150403.zip"

cd %BuildDirectory%