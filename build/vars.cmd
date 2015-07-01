IF EXIST %CD%\vars.user.cmd (
	call %CD%\vars.user.cmd
)

SET BuildDirectory=%CD%
IF NOT DEFINED appcmd SET appcmd=CALL %WINDIR%\system32\inetsrv\appcmd
IF NOT DEFINED SitecoreInstallName SET SitecoreInstallName=Sitecore 8.0 rev. 150621.zip
IF NOT DEFINED SiteName SET SiteName=spitfire
IF NOT DEFINED InstallerPath SET InstallerPath=c:\SpitfireInstaller
IF NOT DEFINED InstanceDirectory SET InstanceDirectory=c:\websites
SET SourceDirectory=%CD:\build=%
IF NOT DEFINED msbuild SET msbuild="C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"
IF NOT DEFINED DbServer SET DbServer=.\SQLEXPRESS
IF NOT DEFINED DbSaPassword SET DbSaPassword=10Philpot
SET DbConnectionString=Data Source=%DbServer%;User ID=sa;Password=%DbSaPassword%