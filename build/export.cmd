@echo off
call vars.cmd

cd /D %InstallerPath%\SIM

echo Purging EventQueue from Core...
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "%SiteName%_Sitecore_core" -Q "DELETE FROM EventQueue"

echo Purging History from Core...
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "%SiteName%_Sitecore_core" -Q "DELETE FROM History"

echo Shrinking databases...
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "master" -Q "DBCC SHRINKDATABASE(%SiteName%_Sitecore_core)"
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "master" -Q "DBCC SHRINKDATABASE(%SiteName%_Sitecore_master)"
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "master" -Q "DBCC SHRINKDATABASE(%SiteName%_Sitecore_web)"
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "master" -Q "DBCC SHRINKDATABASE(%SiteName%_Sitecore_reporting)"

echo Exporting instance using SIM...
Hedgehog.Tds.Build.Sim.Console.exe export "InstanceName:%SiteName%" "ExportFilePath:%1"
cd %BuildDirectory%

pause