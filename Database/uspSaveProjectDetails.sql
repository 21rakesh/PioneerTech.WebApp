
Create Procedure [dbo].[uspSaveProjectDetails]
@EmployeeID Integer,
@Project_Name varchar(50),
@Client_Name varchar(50),
@Location varchar(50),
@Roles varchar(50)

AS
BEGIN
Insert INTO Project_Details(EmployeeID,Project_Name,Client_Name,Location,Roles)values(@EmployeeID,@Project_Name,@Client_Name,@Location,@Roles)
END
GO


