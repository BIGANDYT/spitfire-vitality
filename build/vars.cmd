SET appcmd=CALL %WINDIR%\system32\inetsrv\appcmd
SET SitecoreInstallName=Sitecore 8.0 rev. 150427.zip
SET BaseSite=spitfire
SET InstallerPath=c:\SpitfireInstaller
SET InstanceDirectory=c:\websites
SET DevDirectory=c:\websites\_dev
SET DbConnectionString=Data Source=.\SQLEXPRESS;User ID=sa;Password=10Philpot
SET SourceDirectory=%DevDirectory%\%BaseSite%source
SET BuildDirectory=%SourceDirectory%\build
SET msbuild="C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"