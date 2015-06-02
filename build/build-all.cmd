@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln

if not exist ..\lib\Sitecore (
	mkdir ..\lib\Sitecore
	copy c:\websites\%BaseSite%\Website\bin\Sitecore.*.dll ..\lib\Sitecore
)

call build.cmd %BaseSite% %1