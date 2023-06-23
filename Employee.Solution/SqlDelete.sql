DELETE FROM [dbo].[Employees]


DBCC CHECKIDENT ('[Employees]', RESEED, 0);
