@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln

if not exist %SourceDirectory%\lib\Sitecore (
	mkdir %SourceDirectory%\lib\Sitecore
	copy c:\websites\%BaseSite%\Website\bin\Sitecore.*.dll %SourceDirectory%\lib\Sitecore
)

call build.cmd %BaseSite% %1