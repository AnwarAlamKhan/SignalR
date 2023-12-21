ALTER ROLE [db_owner] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_accessadmin] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_securityadmin] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_ddladmin] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_backupoperator] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_datareader] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_denydatareader] ADD MEMBER [susadmin];


GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [susadmin];

