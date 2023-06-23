SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE UpdateEmployeeSalary
	@EmployeeId INT, @NewSalary INT, @OldSalary INT OUTPUT  
AS
BEGIN
	SET NOCOUNT ON;

	SELECT @OldSalary = Salary FROM Employees WHERE Id = @EmployeeId

	UPDATE Employees 
	SET Salary = @NewSalary
	WHERE Id = @EmployeeId 
END
GO

/** 
RUNNING SP ...

  DECLARE @PreviousSalary INT
  EXEC UpdateEmployeeSalary @EmployeeId = 1, @NewSalary = 55000, @OldSalary = @PreviousSalary OUTPUT
  PRINT @PreviousSalary


**/
