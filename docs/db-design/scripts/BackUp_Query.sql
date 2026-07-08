
--Mohammad

BACKUP DATABASE [UniPlan]
TO DISK = N''
WITH FORMAT, 
     MEDIANAME = 'SQLServerBackups', 
     NAME = 'Full Backup of UniPlan';
GO

-- Fares

BACKUP DATABASE [UniPlan]
TO DISK = N'D:\coding files\Projects\UNI_Project\UniPlan\docs\db-design\scripts\Data.backup'
WITH FORMAT, 
     MEDIANAME = 'SQLServerBackups', 
     NAME = 'Full Backup of UniPlan';
GO