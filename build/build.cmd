@echo off
cd /d %0\..

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%InstanceDirectory%\%sitename%\Website
del %InstanceDirectory%\%sitename%\Website\bin\Spitfire.*

rd /s /q c:\websites\%sitename%\Website\App_Config\Include\zSpitfire

%msbuild% %SourceDirectory%\src\Spitfire.Website\Spitfire.Website.csproj %DeployParameters%

:End1
cd /d %BuildDirectory%