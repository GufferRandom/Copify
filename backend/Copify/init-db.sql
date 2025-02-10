IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'copify')
BEGIN
    CREATE DATABASE [copify];
END