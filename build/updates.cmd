@echo off
cd /d %0\..

echo Installing updates using Sitecore ship
set sitelocation=%InstanceDirectory%\%sitename%\Website

@echo on
tools\curl "http://%sitename%/sitecore_ship/about"

::if not exist "%sitelocation%\bin\Sitecore.WFFM.dll" (
::	tools\curl -F "path=%InstallerPath%\Web Forms for Marketers 8.0 rev. 150625.zip" "http://%sitename%/sitecore_ship/package/install"
::)

if not exist "%sitelocation%\bin\ASR.dll" (
	tools\curl -F "path=%InstallerPath%\Advanced System Reporter 1.7.1 rev. 000000.zip" "http://%sitename%/sitecore_ship/package/install"
)

if not exist "%sitelocation%\bin\ParTech.Modules.SeoUrl.dll" (
	tools\curl -F "path=%InstallerPath%\ParTech.Modules.SeoUrl-1.0.15.zip" "http://%sitename%/sitecore_ship/package/install"
)

if not exist "%sitelocation%\bin\Outercore.FieldTypes.dll" (
	tools\curl -F "path=%InstallerPath%\Outercore.Fieldtypes.zip" "http://%sitename%/sitecore_ship/package/install"
)

if not exist "%sitelocation%\bin\Sitecore.SharedSource.CustomFields.ColorPicker.dll" (
	tools\curl -F "path=%InstallerPath%\ColorPicker Field.zip" "http://%sitename%/sitecore_ship/package/install"
)

if not exist "%sitelocation%\bin\FieldFallback.Kernel.dll" (
	tools\curl -F "path=%InstallerPath%\Kernel.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
)

if not exist "%sitelocation%\bin\FieldFallback.Processors.dll" (
	tools\curl -F "path=%InstallerPath%\Processors.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
)

:: TODO: We won't need this for much longer, will be in Sitecore 8.1
if not exist "%sitelocation%\bin\FieldFallback.Processors.Globalization.dll" (
	tools\curl -F "path=%InstallerPath%\Processors.Globalization.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
)