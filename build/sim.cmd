@echo off

echo Installing %sitename% using SIM...
cd /D %InstallerPath%\SIM
Hedgehog.Tds.Build.Sim.Console.exe install "InstanceName:%sitename%" "InstanceDirectory:%InstanceDirectory%" "RepoDirectory:%InstallerPath%" "RepoFile:%SitecoreInstallName%" "ConnectionString:%DbConnectionString%" "AppPoolIdentity:NetworkService" "LicencePath:%InstallerPath%\license.xml"
robocopy %InstallerPath%\PostInstallFiles %InstanceDirectory%\%sitename%\Website /S /nfl /ndl

cd %BuildDirectory%