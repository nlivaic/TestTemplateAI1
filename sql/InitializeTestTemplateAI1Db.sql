USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplateAI1Db')
BEGIN
  CREATE DATABASE TestTemplateAI1Db;
END;
GO

USE TestTemplateAI1Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplateAI1Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplateAI1Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplateAI1Db_User')
BEGIN
    CREATE USER TestTemplateAI1Db_User FOR LOGIN TestTemplateAI1Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplateAI1Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplateAI1Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplateAI1Db_User';
GO
