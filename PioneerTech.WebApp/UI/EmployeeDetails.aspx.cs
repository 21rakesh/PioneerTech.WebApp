using PioneerDataAccess;
using PioneerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PioneerTech.WebApp.UI
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDetailsModel employee = new EmployeeDetailsModel()
                {
                    First_Name = FirstNameTextBox.Text,
                    Last_Name = LastNameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Mobile_Number = Convert.ToInt64(MobileNumberTextBox.Text),
                    AlternateMobileNumber = Convert.ToInt64(AlternateMobileNumberTextBox.Text),
                    Address1 = Address1TextBox.Text,
                    Address2 = Address2TextBox.Text,
                    Current_Country = CurrentCountryTextBox.Text,
                    Home_Country = HomeCountryTextBox.Text,
                    ZipCode = Convert.ToInt32(ZipCodeTextBox.Text),
                };
                EmployeeDataAccess employeedata = new EmployeeDataAccess();
                employeedata.SaveEmployee(employee);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter the values: " +ex.Message);
            }
           
        }

    }
}