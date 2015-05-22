@echo off
cd /d %0\..

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

IF %2.==. (
	SET DeployParameters=/p:DeployOnBuild=true /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=False /p:publishUrl=%InstanceDirectory%\%sitename%\Website
	del %InstanceDirectory%\%sitename%\Website\bin\%BaseSite%.*

	rd /s /q c:\websites\%sitename%\Website\App_Config\Include\%BaseSite%
	rd /s /q c:\websites\%sitename%\Website\SitecoreAssets
) else (
	SET DeployParameters=
)

if not exist %SourceDirectory%\lib\Sitecore (
	mkdir %SourceDirectory%\lib\Sitecore
	copy c:\websites\%sitename%\Website\bin\Sitecore.*.dll %SourceDirectory%\lib\Sitecore
)

%msbuild% %SourceDirectory%\src\Sites\Base\Web\Base.Web.csproj %DeployParameters%

set siteSpecificProjectFile=%SourceDirectory%\src\Sites\%sitename%\Web\%sitename%.Web.csproj
if exist %siteSpecificProjectFile% (
	%msbuild% %siteSpecificProjectFile% %DeployParameters%
)

:End1
cd /d %BuildDirectory%