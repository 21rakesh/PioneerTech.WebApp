
Create Procedure [dbo].[uspEditCompanyDetails]
@EmployeeID INTEGER,
@Employer_Name varchar(50),
@Contact_Number varchar(50),
@Location varchar(50),
@Website varchar(50)

AS
BEGIN
UPDATE Company_Details
SET Employer_Name=@Employer_Name,Contact_Number=@Contact_Number,Location=@Location,Website=@Website
WHERE EmployeeID=@EmployeeID
END
GO


