@echo off
cd /d %0\..
call vars.cmd

echo Installing updates using Sitecore ship
set sitelocation=%InstanceDirectory%\%sitename%\Website

@echo on
tools\curl -f "http://%sitename%/sitecore_ship/about"

:: Note: We won't need this for much longer, will be in Sitecore 8.1
if not exist "%sitelocation%\bin\Sitecore.Marketing.Campaigns.Client.dll" (
	tools\curl -F "path=%InstallerPath%\Sitecore Campaign Manager 1.0 rev. 150423.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
	
	:: Wrapped this in here to make sure it only runs once, temporary.
	tools\curl -F "path=%InstallerPath%\Microsoft Dynamics CRM Security Provider 2.1 rev. 150403 Hotfix 438309.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\Sitecore.CrmCampaignIntegration.dll" (
	tools\curl -F "path=%InstallerPath%\Dynamics CRM Campaign Integration for WFFM 2.1 rev. 150403.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\ASR.dll" (
	tools\curl -F "path=%InstallerPath%\Advanced System Reporter 1.7.1 rev. 000000.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\ParTech.Modules.SeoUrl.dll" (
	tools\curl -F "path=%InstallerPath%\ParTech.Modules.SeoUrl-1.0.15.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\Outercore.FieldTypes.dll" (
	tools\curl -F "path=%InstallerPath%\Outercore.Fieldtypes.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\Sitecore.SharedSource.CustomFields.ColorPicker.dll" (
	tools\curl -F "path=%InstallerPath%\ColorPicker Field.zip" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\FieldFallback.Kernel.dll" (
	tools\curl -F "path=%InstallerPath%\Kernel.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

if not exist "%sitelocation%\bin\FieldFallback.Processors.dll" (
	tools\curl -F "path=%InstallerPath%\Processors.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

:: Note: We won't need this for much longer, will be in Sitecore 8.1
if not exist "%sitelocation%\bin\FieldFallback.Processors.Globalization.dll" (
	tools\curl -F "path=%InstallerPath%\Processors.Globalization.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
	IF "%ERRORLEVEL%" NEQ "0" (
		echo Package installation failed
		exit /B %ERRORLEVEL%
	)
)

exit /B 0