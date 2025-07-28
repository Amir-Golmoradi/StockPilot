-- ساخت لاگین جدید
CREATE LOGIN amirgolmoradi WITH PASSWORD = 'WubbaLubbaDubDub@RichSanchez6';

-- ساخت دیتابیس
CREATE DATABASE StockPilot;
GO

USE StockPilot;
GO

-- ساخت یوزر داخل دیتابیس و دادن دسترسی کامل
CREATE USER amirgolmoradi FOR LOGIN amirgolmoradi;
ALTER ROLE db_owner ADD MEMBER amirgolmoradi;
GO


