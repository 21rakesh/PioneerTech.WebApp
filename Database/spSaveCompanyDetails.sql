
Create Procedure [dbo].[uspSaveCompanyDetails]
@Employer_Name varchar(50),
@Contact_Number varchar(50),
@Location varchar(50),
@Website varchar(50)

AS
BEGIN
INSERT INTO Company_Details(Employer_Name,Contact_Number,Location,Website)values(@Employer_Name,@Contact_Number,@Location,@Website)
END
GO


