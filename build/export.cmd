@echo off
call vars.cmd

sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "%SiteName%Sitecore_core" -v dbname="%SiteName%Sitecore_core" -i sql-optimize-database.sql
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "%SiteName%Sitecore_master" -v dbname="%SiteName%Sitecore_master" -i sql-optimize-database.sql
sqlcmd -S .\ -U "sa" -P "%DbSaPassword%" -d "%SiteName%Sitecore_web" -v dbname="%SiteName%Sitecore_web" -i sql-optimize-database.sql

cd /D %InstallerPath%\SIM

echo Exporting instance using SIM...
Spitfire.Sim.Console.exe export "InstanceName:%SiteName%" "ExportFilePath:%1"
cd %BuildDirectory%

pause