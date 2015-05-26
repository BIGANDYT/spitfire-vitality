@echo on

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

echo Installing %sitename% using SIM...
cd /D %InstallerPath%\SIM
Hedgehog.Tds.Build.Sim.Console.exe install "InstanceName:%sitename%" "InstanceDirectory:%InstanceDirectory%" "RepoDirectory:%InstallerPath%" "RepoFile:%SitecoreInstallName%" "ConnectionString:%DbConnectionString%" "AppPoolIdentity:NetworkService" "LicencePath:%InstallerPath%\license.xml"
robocopy %InstallerPath%\PostInstallFiles %InstanceDirectory%\%sitename%\Website /S /nfl /ndl

:End1
cd %BuildDirectory%