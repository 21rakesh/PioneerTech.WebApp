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
        public int SaveEmployee(EmployeeDetailsModel employee)
        {
            int result = 0;
            try
            {
                
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" + "Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqlemployeedetails = @"INSERT INTO Employee_Details
                                            (First_Name,Last_Name,Email,Mobile_Number,AlternateMobileNumber,Address1,Adress2,Current_Country,Home_Country,ZipCode)VALUES('" + employee.First_Name + "'," + "" + "'" + employee.Last_Name + "'," + "" + "'" + employee.Email + "'," + "" + "" + employee.Mobile_Number + "," + "" + employee.AlternateMobileNumber + "," + "" + "'" + employee.Address1 + "'," + "'" + employee.Address2 + "'," + "" + "" + "'" + employee.Current_Country + "'," + "'" + employee.Home_Country + "'," + "" + employee.ZipCode + ")";
                SqlCommand command;
                command = new SqlCommand(sqlemployeedetails, mysqlconnection);
                result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Details have been saved Successfully:");
                }
                else
                {
                    MessageBox.Show("please enter values:");
                }
                mysqlconnection.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact the administartor: " + ex.Message);
            }
            return result;
       

        }
    }
    public class EducationDataAccess
    {
        public int SaveEducation(EducationDetailsModel education)
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
                    MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact the administartor: " + ex.Message);
            }
            return result;
        }
        public List<int> GetEmployeeID()
        {

            List<int> empid = new List<int>();
            

                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Education_Details");

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
            try
            {

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
                    detailsmodel.EmployeeID = educationdatareader.GetInt32(educationdatareader.GetOrdinal("EmployeeID"));
                    detailsmodel.CourseType = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseType"));
                    detailsmodel.CourseSpecialisation = educationdatareader.GetString(educationdatareader.GetOrdinal("CourseSpecialisation"));
                    detailsmodel.YearOfPass = educationdatareader.GetInt32(educationdatareader.GetOrdinal("YearOfPass"));
                    
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured please contact the administrator: " + ex.Message);
            }
            return detailsmodel;
        }
        public int Editeducation(EducationDetailsModel edumodel)
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
                    MessageBox.Show("Details have been updated:");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact administrator:" + ex.Message);
            }
            return result;
        }
    }
    public class TechnicalDataAccess
    {
        public int SaveTechnical(TechnicalDetailsModels technical)
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
                    MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact the administartor: " + ex.Message);
            }
            return result;
        }
       
    }
    public class CompanyDataAccess
    {
        public int SaveCompany(CompanyDetailsModel company)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;"+"Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqlcompanydetails = @"INSERT INTO Company_Details(Employer_Name,Contact_Number,Location,Website)VALUES('"+company.Employer_Name+"',"+""+company.Contact_Number+"," + "'" + company.Location + "'," + "'" + company.Website + "')";
                SqlCommand command;
                command = new SqlCommand(sqlcompanydetails, mysqlconnection);
                result=command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact the administartor: " + ex.Message);
            }
            return result;
        }
        public List<int> GetEmployeeID()
        {
            
            List<int> empid = new List<int>();
            try
            {
                
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                       " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sqldetails = ("Select * FROM Company_Details");
                
                SqlCommand command;
                command = new SqlCommand(sqldetails, mysqlconnection);
                SqlDataReader employeeiddata = command.ExecuteReader();
                while (employeeiddata.Read())
                {
                     empid.Add(
                         employeeiddata.GetInt32(employeeiddata.GetOrdinal("EmployeeID"))

                     );
                   
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has been occured please contact the administrator: " + ex.Message);
            }
            return empid;
        }
        public CompanyDetailsModel GetCompanyDetails(int employeeid)
        {
            CompanyDetailsModel details = new CompanyDetailsModel();
            try
            {

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
                    details.Contact_Number = companydatareader.GetInt64(companydatareader.GetOrdinal("Contact_Number"));
                    details.Location = companydatareader.GetString(companydatareader.GetOrdinal("Location"));
                    details.Website = companydatareader.GetString(companydatareader.GetOrdinal("Website"));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured please contact the administrator: " + ex.Message);
            }
            return details;
        }
        public int EditCompany(CompanyDetailsModel companydetails)
        {
            int result = 0;
            try
            {
                string connectionstring = "Data Source=RAKI;Initial Catalog=PioneerEmployeeDB;" +
                      " Integrated Security=True";
                SqlConnection mysqlconnection = new SqlConnection(connectionstring);
                mysqlconnection.Open();
                string sql = @"UPDATE Company_Details SET Employer_Name='"+companydetails.Employer_Name+"',Contact_Number="+companydetails.Contact_Number+",Location='"+companydetails.Location+"',Website='"+companydetails.Website+"' WHERE EmployeeID="+companydetails.EmployeeID+"";
                SqlCommand command;
                command = new SqlCommand(sql, mysqlconnection);
                result = command.ExecuteNonQuery();
                if(result>0)
                {
                    MessageBox.Show("Details have been updated:");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact administrator:" +ex.Message);
            }
            return result;
        }
    }
    public class ProjectDataAccess
    {
        public int SaveProject(ProjectDetailsModel project)
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
                result=command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Details have been saved Successfully:");
                }
                mysqlconnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has been occured, please contact the administartor: " + ex.Message);
            }
            return result;
        }
    } 
   

}


