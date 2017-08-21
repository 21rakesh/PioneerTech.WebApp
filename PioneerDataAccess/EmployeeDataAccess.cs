using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using PioneerTest.Models;
using System.Data;

namespace PioneerDataAccess
{
    
    public class EmployeeDataAccess
    {
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        protected void CloseConncetion(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
        public string SaveEmployee(EmployeeDetailsModel employee)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEmployeeDetails";

                sqlCommand.Parameters.Add("@First_name", SqlDbType.VarChar).Value = employee.First_Name;
                sqlCommand.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = employee.Last_Name;
                sqlCommand.Parameters.Add("@Mobile_Number", SqlDbType.VarChar).Value = employee.Mobile_Number;
                sqlCommand.Parameters.Add("@AlternateMobileNumber", SqlDbType.VarChar).Value = employee.AlternateMobileNumber;
                sqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar).Value = employee.Address1;
                sqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar).Value = employee.Address2;
                sqlCommand.Parameters.Add("@Current_Country", SqlDbType.VarChar).Value = employee.Current_Country;
                sqlCommand.Parameters.Add("@Home_Country", SqlDbType.VarChar).Value = employee.Home_Country;
                sqlCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = employee.ZipCode;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";

            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public List<int> GetEmployeeID()
        {
            try
            {
                List<int> empid = new List<int>();
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspGetEmployeeID";
                SqlDataReader employeeiddata = sqlCommand.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
                sqlCommand.Dispose();
                return empid;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public EmployeeDetailsModel GetEmployeeDetails(int employeeid)
        {
            EmployeeDetailsModel empdmodel = new EmployeeDetailsModel();

            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEmployeeDetails";
            sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeid);
            SqlDataReader employeedatareader = sqlCommand.ExecuteReader();
                while (employeedatareader.Read())
                {
                    empdmodel.EmployeeID = employeedatareader.GetInt32(employeedatareader.GetOrdinal("EmployeeID"));
                    empdmodel.First_Name = employeedatareader.GetString(employeedatareader.GetOrdinal("First_Name"));
                    empdmodel.Last_Name = employeedatareader.GetString(employeedatareader.GetOrdinal("Last_Name"));
                    empdmodel.Email = employeedatareader.GetString(employeedatareader.GetOrdinal("Email"));
                    empdmodel.Mobile_Number = employeedatareader.GetString(employeedatareader.GetOrdinal("Mobile_Number"));
                    empdmodel.AlternateMobileNumber = employeedatareader.GetString(employeedatareader.GetOrdinal("AlternateMobileNumber"));
                    empdmodel.Address1 = employeedatareader.GetString(employeedatareader.GetOrdinal("Address1"));
                    empdmodel.Address2 = employeedatareader.GetString(employeedatareader.GetOrdinal("Address2"));
                    empdmodel.Current_Country = employeedatareader.GetString(employeedatareader.GetOrdinal("Current_Country"));
                    empdmodel.Home_Country = employeedatareader.GetString(employeedatareader.GetOrdinal("Home_Country"));
                    empdmodel.ZipCode = employeedatareader.GetInt64(employeedatareader.GetOrdinal("ZipCode"));
                }
            CloseConncetion(sqlConnection);
           
            return empdmodel;
        }
        public string Editemployee(EmployeeDetailsModel emmodel)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspEditEmployeeDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = emmodel.EmployeeID.ToString();
                sqlCommand.Parameters.Add("@First_name", SqlDbType.VarChar).Value = emmodel.First_Name;
                sqlCommand.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = emmodel.Last_Name;
                sqlCommand.Parameters.Add("@Mobile_Number", SqlDbType.VarChar).Value = emmodel.Mobile_Number;
                sqlCommand.Parameters.Add("@AlternateMobileNumber", SqlDbType.VarChar).Value = emmodel.AlternateMobileNumber;
                sqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar).Value = emmodel.Address1;
                sqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar).Value = emmodel.Address2;
                sqlCommand.Parameters.Add("@Current_Country", SqlDbType.VarChar).Value = emmodel.Current_Country;
                sqlCommand.Parameters.Add("@Home_Country", SqlDbType.VarChar).Value = emmodel.Home_Country;
                sqlCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = emmodel.ZipCode;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
           
        }
    }
    public class EducationDataAccess
    {
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        protected void CloseConncetion(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
        public string SaveEducation(EducationDetailsModel education)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveEducationDetails";
                sqlCommand.Parameters.Add("@CourseType", SqlDbType.VarChar).Value = education.CourseType;
                sqlCommand.Parameters.Add("@YearOfPass", SqlDbType.Int).Value = education.YearOfPass.ToString();
                sqlCommand.Parameters.Add("@CourseSpecialisation", SqlDbType.VarChar).Value = education.CourseSpecialisation;
                result =sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEmployeeID";
                SqlDataReader employeeiddata = sqlCommand.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
            CloseConncetion(sqlConnection);
            return empid;
        }
        public EducationDetailsModel GetEducationDetails(int empid)
        {
            EducationDetailsModel detailsmodel = new EducationDetailsModel();

            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEducationDetails";
            sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(empid);
            SqlDataReader educationdatareader = sqlCommand.ExecuteReader();
            while (educationdatareader.Read())
                {
                    detailsmodel.EmployeeID= educationdatareader.GetInt32(educationdatareader.GetOrdinal("EmployeeID"));
                    detailsmodel.CourseType = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseType"));
                    detailsmodel.CourseSpecialisation = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseSpecialisation"));
                    detailsmodel.YearOfPass = educationdatareader.GetInt32(educationdatareader.GetOrdinal("YearOfPass"));
                    
                   
                }
            CloseConncetion(sqlConnection);
            return detailsmodel;
        }
        public string Editeducation(EducationDetailsModel edumodel)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspEditEducationDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = edumodel.EmployeeID.ToString();
                sqlCommand.Parameters.Add("@CourseType", SqlDbType.VarChar).Value = edumodel.CourseType;
                sqlCommand.Parameters.Add("@YearOfPass", SqlDbType.Int).Value = edumodel.YearOfPass.ToString();
                sqlCommand.Parameters.Add("@CourseSpecialisation", SqlDbType.VarChar).Value = edumodel.CourseSpecialisation;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
    }
    public class TechnicalDataAccess
    {
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        protected void CloseConncetion(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
        public string SaveTechnical(TechnicalDetailsModels technical)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveTechnicalDetails";
                sqlCommand.Parameters.Add("@UI", SqlDbType.VarChar).Value = technical.UI;
                sqlCommand.Parameters.Add("Programming_Languages", SqlDbType.VarChar).Value = technical.Programming_Languages;
                sqlCommand.Parameters.Add("ORM_Technologies", SqlDbType.VarChar).Value = technical.ORM_Technologies;
                sqlCommand.Parameters.Add("Databases", SqlDbType.VarChar).Value = technical.Databases;
                result=sqlCommand.ExecuteNonQuery();
                if (result>0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEmployeeID";
                SqlDataReader employeeiddata = sqlCommand.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
            CloseConncetion(sqlConnection);
            return empid;
        }
        public TechnicalDetailsModels GetTechnicalDetails(int employeeid)
        {
            TechnicalDetailsModels techdetails = new TechnicalDetailsModels();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetTechnicalDetails";
            sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeid);
                SqlDataReader technicaldatareader = sqlCommand.ExecuteReader();
                while (technicaldatareader.Read())
                {
                    techdetails.EmployeeID = technicaldatareader.GetInt32(technicaldatareader.GetOrdinal("EmployeeID"));
                    techdetails.UI = technicaldatareader.GetString(technicaldatareader.GetOrdinal("UI"));
                    techdetails.Programming_Languages = technicaldatareader.GetString(technicaldatareader.GetOrdinal("Programming_Languages"));
                    techdetails.ORM_Technologies = technicaldatareader.GetString(technicaldatareader.GetOrdinal("ORM_Technologies"));
                    techdetails.Databases = technicaldatareader.GetString(technicaldatareader.GetOrdinal("Databases"));
                }
            CloseConncetion(sqlConnection);
            return techdetails;
        }
        public string EditTechnical(TechnicalDetailsModels technicaldetails)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspEditTechnicalDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = technicaldetails.EmployeeID;
                sqlCommand.Parameters.Add("@UI", SqlDbType.VarChar).Value = technicaldetails.UI;
                sqlCommand.Parameters.Add("Programming_Languages", SqlDbType.VarChar).Value = technicaldetails.Programming_Languages;
                sqlCommand.Parameters.Add("ORM_Technologies", SqlDbType.VarChar).Value = technicaldetails.ORM_Technologies;
                sqlCommand.Parameters.Add("Databases", SqlDbType.VarChar).Value = technicaldetails.Databases;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }

    }
    public class CompanyDataAccess
    {
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        protected void CloseConncetion(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
        public string SaveCompany(CompanyDetailsModel company)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveCompanyDetails";
                sqlCommand.Parameters.Add("Employer_Name", SqlDbType.VarChar).Value = company.Employer_Name;
                sqlCommand.Parameters.Add("Contact_Number", SqlDbType.VarChar).Value = company.Contact_Number;
                sqlCommand.Parameters.Add("Location", SqlDbType.VarChar).Value = company.Location;
                sqlCommand.Parameters.Add("Website", SqlDbType.VarChar).Value = company.Website;
                result=sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch(Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public List<int> GetEmployeeID()
        {
            
            List<int> empid = new List<int>();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEmployeeID";
                SqlDataReader employeeiddata = sqlCommand.ExecuteReader();
                while (employeeiddata.Read())
                {
                     empid.Add(
                         employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                     );
                   
                }
            CloseConncetion(sqlConnection);
            return empid;
        }
        public CompanyDetailsModel GetCompanyDetails(int employeeid)
        {
            CompanyDetailsModel details = new CompanyDetailsModel();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetCompanyDetails";
            sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeid);
                SqlDataReader companydatareader = sqlCommand.ExecuteReader();
                while (companydatareader.Read())
                {
                    details.EmployeeID = companydatareader.GetInt32(companydatareader.GetOrdinal("EmployeeID"));
                    details.Employer_Name = companydatareader.GetString(companydatareader.GetOrdinal("Employer_Name"));
                    details.Contact_Number = companydatareader.GetString(companydatareader.GetOrdinal("Contact_Number"));
                    details.Location = companydatareader.GetString(companydatareader.GetOrdinal("Location"));
                    details.Website = companydatareader.GetString(companydatareader.GetOrdinal("Website"));
                }
            CloseConncetion(sqlConnection);
            return details;
        }
        public string EditCompany(CompanyDetailsModel companydetails)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspEditCompanyDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = companydetails.EmployeeID.ToString();
                sqlCommand.Parameters.Add("@Employer_Name", SqlDbType.VarChar).Value = companydetails.Employer_Name;
                sqlCommand.Parameters.Add("@Contact_Number", SqlDbType.VarChar).Value = companydetails.Contact_Number;
                sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = companydetails.Location;
                sqlCommand.Parameters.Add("@Website", SqlDbType.VarChar).Value = companydetails.Website;
                result = sqlCommand.ExecuteNonQuery();
                if(result>0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" +ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
    }
    public class ProjectDataAccess
    {
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;
        protected SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True");
            sqlConnection.Open();
            return sqlConnection;
        }
        protected void CloseConncetion(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }
        public string SaveProject(ProjectDetailsModel project)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspSaveProjectDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = project.EmployeeID.ToString();
                sqlCommand.Parameters.Add("@Project_Name", SqlDbType.VarChar).Value = project.Project_Name;
                sqlCommand.Parameters.Add("@Client_Name", SqlDbType.VarChar).Value = project.Client_Name;
                sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = project.Location;
                sqlCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = project.Roles;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetEmployeeID";
                SqlDataReader employeeiddata = sqlCommand.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
            CloseConncetion(sqlConnection);
            return empid;
        }
        public ProjectDetailsModel GetProjectDetails(int employeeid)
        {
            ProjectDetailsModel prjdetails = new ProjectDetailsModel();
            sqlConnection = OpenConnection();
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "uspGetProjectDetails";
            sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(employeeid);
                SqlDataReader projectdatareader = sqlCommand.ExecuteReader();
                while (projectdatareader.Read())
                {
                    prjdetails.EmployeeID = projectdatareader.GetInt32(projectdatareader.GetOrdinal("EmployeeID"));
                    prjdetails.Project_Name = projectdatareader.GetString(projectdatareader.GetOrdinal("Project_Name"));
                    prjdetails.Client_Name = projectdatareader.GetString(projectdatareader.GetOrdinal("Client_Name"));
                    prjdetails.Location = projectdatareader.GetString(projectdatareader.GetOrdinal("Location"));
                    prjdetails.Roles = projectdatareader.GetString(projectdatareader.GetOrdinal("Roles"));
                }
            CloseConncetion(sqlConnection);
            return prjdetails;
        }
        public string EditProject(ProjectDetailsModel projectdetails)
        {
            int result = 0;
            try
            {
                sqlConnection = OpenConnection();
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "uspEditProjectDetails";
                sqlCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = projectdetails.EmployeeID;
                sqlCommand.Parameters.Add("@Project_Name", SqlDbType.VarChar).Value = projectdetails.Project_Name;
                sqlCommand.Parameters.Add("@Client_Name", SqlDbType.VarChar).Value = projectdetails.Client_Name;
                sqlCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = projectdetails.Location;
                sqlCommand.Parameters.Add("@Roles", SqlDbType.VarChar).Value = projectdetails.Roles;
                result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
            finally
            {
                CloseConncetion(sqlConnection);
            }
        }
    } 
   

}


