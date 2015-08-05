@echo off
cd /d %0\..
call vars.cmd

echo Installing %sitename% using SIM...

:: Clear SIM cache
IF EXIST "%appdata%\Sitecore\Sitecore Instance Manager\Caches\manifest.txt" DEL /Q "%appdata%\Sitecore\Sitecore Instance Manager\Caches\*"

cd /D %InstallerPath%\SIM
Spitfire.Sim.Console.exe install "InstanceName:%sitename%" "InstanceDirectory:%InstanceDirectory%" "RepoDirectory:%InstallerPath%" "RepoFile:%SitecoreInstallName%" "ConnectionString:%DbConnectionString%" "AppPoolIdentity:NetworkService" "LicencePath:%InstallerPath%\license.xml" "Modules:Spitfire PostInstall 1.0 rev. 000000.zip|Web Forms for Marketers 8.0 rev. 150625.zip|Email Experience Manager 3.1 rev. 150703.zip|Microsoft Dynamics CRM Security Provider 2.1 rev. 150403.zip"

cd %BuildDirectory%