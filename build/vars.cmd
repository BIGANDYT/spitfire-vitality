IF NOT DEFINED appcmd SET appcmd=CALL %WINDIR%\system32\inetsrv\appcmd
IF NOT DEFINED SitecoreInstallName SET SitecoreInstallName=Sitecore 8.0 rev. 150427.zip
IF NOT DEFINED BaseSite SET BaseSite=spitfire
IF NOT DEFINED InstallerPath SET InstallerPath=c:\SpitfireInstaller
IF NOT DEFINED InstanceDirectory SET InstanceDirectory=c:\websites
IF NOT DEFINED DevDirectory SET DevDirectory=c:\websites\_dev
IF NOT DEFINED DbConnectionString SET DbConnectionString=Data Source=.\SQLEXPRESS;User ID=sa;Password=10Philpot
IF NOT DEFINED SourceDirectory SET SourceDirectory=%DevDirectory%\spitfiresource
IF NOT DEFINED BuildDirectory SET BuildDirectory=%SourceDirectory%\build
IF NOT DEFINED msbuild SET msbuild="C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"