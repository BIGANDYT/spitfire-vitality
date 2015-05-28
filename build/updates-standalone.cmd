@echo off
cd /d %0\..

call vars.cmd

:: Copy SIM + installation packages to c:\SpitfireInstaller
call sync-installer.cmd

:: Install updates using Sitecore Ship
call updates.cmd %BaseSite%