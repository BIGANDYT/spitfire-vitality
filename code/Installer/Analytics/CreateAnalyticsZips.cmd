cd /d %0\..
SET RootFolder=C:\Websites\paddypower
SET Zip=..\7zip\7z.exe a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on
SET MongoDump=c:\mongodb\bin\mongodump -o MongoDatabases -db

iisreset /stop

del *.zip

::DO MONGO
rd /S /Q MongoDatabases

%MongoDump% paddypower_analytics
ren MongoDatabases\paddypower_analytics analytics

%MongoDump% paddypower_ecm_dispatch
ren MongoDatabases\paddypower_ecm_dispatch ecm_dispatch

%MongoDump% paddypower_tracking_contact
ren MongoDatabases\paddypower_tracking_contact tracking_contact

%MongoDump% paddypower_tracking_history
ren MongoDatabases\paddypower_tracking_history tracking_history

%MongoDump% paddypower_tracking_live
ren MongoDatabases\paddypower_tracking_live tracking_live

%Zip% MongoDatabases.zip MongoDatabases
rd /S /Q MongoDatabases

::DO LUCENE
%Zip% sitecore_analytics_index.zip %RootFolder%\Data\indexes\sitecore_analytics_index

::DO SQL
del *.bak

::TODO: Get credentials from ConnectionStrings.config
sqlcmd -S .\ -U sa -P 10Philpot -Q "DBCC SHRINKDATABASE ([paddypowerSitecore_reporting])"
sqlcmd -S .\ -U sa -P 10Philpot -Q "BACKUP DATABASE [paddypowerSitecore_reporting] TO DISK = '%CD%\reporting.bak' WITH FORMAT, MEDIANAME='paddypower_Analytics', NAME='paddypower_Analytics Full Backup'"

%Zip% SitecoreReporting.zip reporting.bak

del *.bak

iisreset /start
pause