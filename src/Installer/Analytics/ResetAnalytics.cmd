cd /d %0\..
SET Prefix=demo
SET RootFolder=C:\Websites\paddypower
SET UnZip=..\7zip\7z.exe x

iisreset /stop

::DO MONGO
rd /s /q MongoDatabases
%UnZip% MongoDatabases.zip

c:\mongodb\bin\mongo paddypower_analytics --eval "db.dropDatabase()"
c:\mongodb\bin\mongo paddypower_ecm_dispatch --eval "db.dropDatabase()"
c:\mongodb\bin\mongo paddypower_tracking_contact --eval "db.dropDatabase()"
c:\mongodb\bin\mongo paddypower_tracking_history --eval "db.dropDatabase()"
c:\mongodb\bin\mongo paddypower_tracking_live --eval "db.dropDatabase()"

c:\mongodb\bin\mongorestore --drop --db paddypower_analytics MongoDatabases\analytics
c:\mongodb\bin\mongorestore --drop --db paddypower_ecm_dispatch MongoDatabases\ecm_dispatch
c:\mongodb\bin\mongorestore --drop --db paddypower_tracking_contact MongoDatabases\tracking_contact
c:\mongodb\bin\mongorestore --drop --db paddypower_tracking_history MongoDatabases\tracking_history
c:\mongodb\bin\mongorestore --drop --db paddypower_tracking_live MongoDatabases\tracking_live
rd /s /q MongoDatabases

::DO LUCENE
rd /s /q sitecore_analytics_index
%UnZip% sitecore_analytics_index.zip
robocopy sitecore_analytics_index %RootFolder%\Data\indexes\sitecore_analytics_index /mir /Z /nfl /ndl
rd /s /q sitecore_analytics_index

::DO SQL
del *.bak
%UnZip% SitecoreReporting.zip
::TODO: Get from ConnectionStrings.config
sqlcmd -S .\SQLEXPRESS -U sa -P 10Philpot -Q "sp_detach_db [paddypowerSitecore_reporting]"
del %RootFolder%\Databases\*Analytics*
del %RootFolder%\Databases\*Reporting*
sqlcmd -S .\SQLEXPRESS -U sa -P 10Philpot -Q "RESTORE DATABASE [paddypowerSitecore_reporting] FROM DISK = '%CD%\reporting.bak' WITH MOVE 'Sitecore.Analytics' TO '%RootFolder%\Databases\paddypowerSitecore_reporting.mdf', MOVE 'Sitecore.Analytics_log' TO '%RootFolder%\Databases\paddypowerSitecore_reporting.ldf'"
del *.bak

iisreset /start
pause