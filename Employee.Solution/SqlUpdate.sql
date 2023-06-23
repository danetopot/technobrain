USE [TechnoBrain]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeSalary]    Script Date: 6/22/2023 2:28:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[UpdateEmployeeSalary]
	@EmployeeId INT, @NewSalary INT, @OldSalary INT OUTPUT  
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @OldSalary = Salary FROM Employees WHERE Id = @EmployeeId

	UPDATE Employees 
	SET Salary = @NewSalary
	WHERE Id = @EmployeeId 
END
