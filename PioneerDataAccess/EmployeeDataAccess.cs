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
        public string SaveEmployee(EmployeeDetailsModel employee)
        {
            int result = 0;
            try
            {

                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqlemployeedetails = @"INSERT INTO Employee_Details
                                            (First_Name,Last_Name,Email,Mobile_Number,AlternateMobileNumber,Address1,Address2,Current_Country,Home_Country,ZipCode)VALUES('" + employee.First_Name + "'," + "" + "'" + employee.Last_Name + "'," + "" + "'" + employee.Email + "','" + "" + employee.Mobile_Number + "','" + "" + employee.AlternateMobileNumber + "'," + "" + "'" + employee.Address1 + "'," + "'" + employee.Address2 + "'," + "" + "" + "'" + employee.Current_Country + "'," + "'" + employee.Home_Country + "'," + "" + employee.ZipCode + ")";
                SqlCommand command;
                command = new SqlCommand(sqlemployeedetails, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                    // MessageBox.Show("Details have been saved Successfully:");
                    //Response.Write("<script>alert('Details have been saved successfully!);</script>");
                }
                
                mysqlconnection.Close();
                return "failed";

            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
        

                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details");

                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
        
            return empid;
        }
        public EmployeeDetailsModel GetEmployeeDetails(int employeeid)
        {
            EmployeeDetailsModel empdmodel = new EmployeeDetailsModel();
           
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details WHERE EmployeeID=" + employeeid);
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeedatareader = command.ExecuteReader();
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

           
            return empdmodel;
        }
        public string Editemployee(EmployeeDetailsModel emmodel)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Employee_Details SET First_Name='" + emmodel.First_Name + "',Last_Name='" + emmodel.Last_Name + "',Email='" + emmodel.Email + "',Mobile_Number='" + emmodel.Mobile_Number + "',AlternateMobileNumber='" + emmodel.AlternateMobileNumber + "',Address1='" + emmodel.Address1 + "',Address2='" + emmodel.Address2 + "',Current_Country='" + emmodel.Current_Country + "',Home_Country='" + emmodel.Home_Country + "',ZipCode=" + emmodel.ZipCode + " WHERE EmployeeID=" + emmodel.EmployeeID + "";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                    //MessageBox.Show("Details have been updated:");
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
           
        }
    }
    public class EducationDataAccess
        {
        public string SaveEducation(EducationDetailsModel education)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;"+"Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqleducationdetails = @"INSERT INTO Education_Details(CourseType,CourseSpecialisation,YearOfPass)VALUES('"+education.CourseType+"','"+ education.CourseSpecialisation+"',"+education.YearOfPass+")";
                SqlCommand command;
                command = new SqlCommand(sqleducationdetails, mysqlconnection);
                result =command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                    //MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
            
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
            

                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details");

                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }

            return empid;
        }
        public EducationDetailsModel GetEducationDetails(int employeeid)
        {
            EducationDetailsModel detailsmodel = new EducationDetailsModel();
           
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Education_Details WHERE EmployeeID=" + employeeid);
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader educationdatareader = command.ExecuteReader();
                while (educationdatareader.Read())
                {
                    detailsmodel.EmployeeID= educationdatareader.GetInt32(educationdatareader.GetOrdinal("EmployeeID"));
                    detailsmodel.CourseType = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseType"));
                    detailsmodel.CourseSpecialisation = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseSpecialisation"));
                    detailsmodel.YearOfPass = educationdatareader.GetInt32(educationdatareader.GetOrdinal("YearOfPass"));
                    
                   
                }
            return detailsmodel;
        }
        public string Editeducation(EducationDetailsModel edumodel)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Education_Details SET CourseType='" + edumodel.CourseType + "',CourseSpecialisation='" + edumodel.CourseSpecialisation + "',YearOfPass=" + edumodel.YearOfPass +" WHERE EmployeeID=" +edumodel.EmployeeID + "";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                    //MessageBox.Show("Details have been updated:");
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
        }
    }
    public class TechnicalDataAccess
    {
        public string SaveTechnical(TechnicalDetailsModels technical)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqltechnicaldetails = @"INSERT INTO Technical_Details(UI,Programming_Languages,ORM_Technologies,Databases)VALUES('" + technical.UI + "'," + "'" + technical.Programming_Languages + "'," + "'" + technical.ORM_Technologies + "'," + "'" + technical.Databases + "')";
                SqlCommand command;
                command = new SqlCommand(sqltechnicaldetails, mysqlconnection);
                result=command.ExecuteNonQuery();
                if (result>0)
                {
                    return "success";
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details");

                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
            return empid;
        }
        public TechnicalDetailsModels GetTechnicalDetails(int employeeid)
        {
            TechnicalDetailsModels techdetails = new TechnicalDetailsModels();
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Technical_Details WHERE EmployeeID=" + employeeid);
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader technicaldatareader = command.ExecuteReader();
                while (technicaldatareader.Read())
                {
                    techdetails.EmployeeID = technicaldatareader.GetInt32(technicaldatareader.GetOrdinal("EmployeeID"));
                    techdetails.UI = technicaldatareader.GetString(technicaldatareader.GetOrdinal("UI"));
                    techdetails.Programming_Languages = technicaldatareader.GetString(technicaldatareader.GetOrdinal("Programming_Languages"));
                    techdetails.ORM_Technologies = technicaldatareader.GetString(technicaldatareader.GetOrdinal("ORM_Technologies"));
                    techdetails.Databases = technicaldatareader.GetString(technicaldatareader.GetOrdinal("Databases"));
                }
            return techdetails;
        }
        public string EditTechnical(TechnicalDetailsModels technicaldetails)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Technical_Details SET UI='" + technicaldetails.UI + "',Programming_Languages='" + technicaldetails.Programming_Languages + "',ORM_Technologies='" + technicaldetails.ORM_Technologies + "',Databases='" + technicaldetails.Databases + "' WHERE EmployeeID=" + technicaldetails.EmployeeID + "";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
        }

    }
    public class CompanyDataAccess
    {
        public string SaveCompany(CompanyDetailsModel company)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;"+"Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqlcompanydetails = @"INSERT INTO Company_Details(Employer_Name,Contact_Number,Location,Website)VALUES('"+company.Employer_Name+"','"+""+company.Contact_Number+"'," + "'" + company.Location + "'," + "'" + company.Website + "')";
                SqlCommand command;
                command = new SqlCommand(sqlcompanydetails, mysqlconnection);
                result=command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                    //MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch(Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
        }
        public List<int> GetEmployeeID()
        {
            
            List<int> empid = new List<int>();  
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details");
                
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                     empid.Add(
                         employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                     );
                   
                }
            return empid;
        }
        public CompanyDetailsModel GetCompanyDetails(int employeeid)
        {
            CompanyDetailsModel details = new CompanyDetailsModel();
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Company_Details WHERE EmployeeID="+employeeid);
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader companydatareader = command.ExecuteReader();
                while (companydatareader.Read())
                {
                    details.EmployeeID = companydatareader.GetInt32(companydatareader.GetOrdinal("EmployeeID"));
                    details.Employer_Name = companydatareader.GetString(companydatareader.GetOrdinal("Employer_Name"));
                    details.Contact_Number = companydatareader.GetString(companydatareader.GetOrdinal("Contact_Number"));
                    details.Location = companydatareader.GetString(companydatareader.GetOrdinal("Location"));
                    details.Website = companydatareader.GetString(companydatareader.GetOrdinal("Website"));
                }
           
            return details;
        }
        public string EditCompany(CompanyDetailsModel companydetails)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Company_Details SET Employer_Name='"+companydetails.Employer_Name+"',Contact_Number='"+companydetails.Contact_Number+"',Location='"+companydetails.Location+"',Website='"+companydetails.Website+"' WHERE EmployeeID="+companydetails.EmployeeID+"";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if(result>0)
                {
                    return "success";
                    //MessageBox.Show("Details have been updated:");
                }
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" +ex.Message;
            }
        }
    }
    public class ProjectDataAccess
    {
        public string SaveProject(ProjectDetailsModel project)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                   " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqlprojectdetails = @"INSERT INTO Project_Details(EmployeeID,Project_Name,Client_Name,Location,Roles)VALUES(" + project.EmployeeID + "," + "'" + project.Project_Name + "'," + "'" + project.Client_Name + "'," + "'" + project.Location + "'," + "'" + project.Roles + "')";
                SqlCommand command;
                command = new SqlCommand(sqlprojectdetails, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact the administartor: " + ex.Message;
            }
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Employee_Details");

                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                    empid.Add(
                        employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                    );

                }
            return empid;
        }
        public ProjectDetailsModel GetProjectDetails(int employeeid)
        {
            ProjectDetailsModel prjdetails = new ProjectDetailsModel();
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Project_Details WHERE EmployeeID=" + employeeid);
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader projectdatareader = command.ExecuteReader();
                while (projectdatareader.Read())
                {
                    prjdetails.EmployeeID = projectdatareader.GetInt32(projectdatareader.GetOrdinal("EmployeeID"));
                    prjdetails.Project_Name = projectdatareader.GetString(projectdatareader.GetOrdinal("Project_Name"));
                    prjdetails.Client_Name = projectdatareader.GetString(projectdatareader.GetOrdinal("Client_Name"));
                    prjdetails.Location = projectdatareader.GetString(projectdatareader.GetOrdinal("Location"));
                    prjdetails.Roles = projectdatareader.GetString(projectdatareader.GetOrdinal("Roles"));
                }
            return prjdetails;
        }
        public string EditProject(ProjectDetailsModel projectdetails)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Project_Details SET EmployeeID=" + projectdetails.EmployeeID + ",Project_Name='" + projectdetails.Project_Name + "',Client_Name='"+ projectdetails.Client_Name+"',Location = '" + projectdetails.Location + "',Roles='" + projectdetails.Roles + "' WHERE EmployeeID=" + projectdetails.EmployeeID + "";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return "success";
                }
                mysqlconnection.Close();
                return "failed";
            }
            catch (Exception ex)
            {
                return "An error has been occured, please contact administrator:" + ex.Message;
            }
        }
    } 
   

}


