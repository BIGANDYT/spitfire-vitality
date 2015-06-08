IF NOT DEFINED BuildDirectory SET BuildDirectory=%CD%
IF NOT DEFINED appcmd SET appcmd=CALL %WINDIR%\system32\inetsrv\appcmd
IF NOT DEFINED SitecoreInstallName SET SitecoreInstallName=Sitecore 8.0 rev. 150427.zip
IF NOT DEFINED SiteName SET SiteName=spitfire
IF NOT DEFINED InstallerPath SET InstallerPath=c:\SpitfireInstaller
IF NOT DEFINED InstanceDirectory SET InstanceDirectory=c:\websites
IF NOT DEFINED DevDirectory SET DevDirectory=c:\websites\_dev
IF NOT DEFINED DbServer SET DbServer=.\SQLEXPRESS
IF NOT DEFINED DbSaPassword SET DbSaPassword=10Philpot
IF NOT DEFINED DbConnectionString SET DbConnectionString=Data Source=%DbServer%;User ID=sa;Password=%DbSaPassword%
IF NOT DEFINED SourceDirectory SET SourceDirectory=%DevDirectory%\spitfiresource
IF NOT DEFINED msbuild SET msbuild="C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"