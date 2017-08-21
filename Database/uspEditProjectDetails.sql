
Create Procedure [dbo].[uspEditProjectDetails]
@EmployeeID Integer,
@Project_Name varchar(50),
@Client_Name varchar(50),
@Location varchar(50),
@Roles varchar(50)

AS
BEGIN
UPDATE Project_Details
SET EmployeeID=@EmployeeID,Project_Name=@Project_Name,Client_Name=@Client_Name,Location=@Location,Roles=@Roles
WHERE EmployeeID=@EmployeeID
END
GO


