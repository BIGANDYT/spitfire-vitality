@echo off
cd /d %0\..

IF %1.==. (
	echo Sitename missing
	GOTO End1
)

SET sitename=%1

echo Installing updates using Sitecore ship
iisreset

@echo on
tools\curl "http://%sitename%/sitecore_ship/about"
tools\curl -F "path=%InstallerPath%\Advanced System Reporter 1.7.1 rev. 000000.zip" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\ParTech.Modules.SeoUrl-1.0.15.zip" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\Outercore.Fieldtypes.zip" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\ColorPicker Field.zip" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\Kernel.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\Processors.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"
tools\curl -F "path=%InstallerPath%\Processors.Globalization.Sitecore.Master.update" "http://%sitename%/sitecore_ship/package/install"

:End1