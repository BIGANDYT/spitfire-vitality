@echo off
cd /d %0\..

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%InstanceDirectory%\%sitename%\Website
del %InstanceDirectory%\%sitename%\Website\bin\%BaseSite%.*

rd /s /q c:\websites\%sitename%\Website\App_Config\Include\z%BaseSite%
::rd /s /q c:\websites\%sitename%\Website\SitecoreAssets

if not exist %SourceDirectory%\lib (
	mkdir %SourceDirectory%\lib
	copy c:\websites\%sitename%\Website\bin\Sitecore.*.dll %SourceDirectory%\lib
)

%msbuild% %SourceDirectory%\src\Spitfire.Website\Spitfire.Website.csproj %DeployParameters%

:End1
cd /d %BuildDirectory%