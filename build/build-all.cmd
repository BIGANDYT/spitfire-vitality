@echo off
cd /d %0\..

call vars.cmd

.\tools\NuGet.exe restore ..\Spitfire.sln
call build.cmd %BaseSite% %1