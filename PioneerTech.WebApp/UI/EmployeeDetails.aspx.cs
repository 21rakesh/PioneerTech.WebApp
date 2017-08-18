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
            if (!IsPostBack)
            {
                EmployeeDataAccess empobj = new EmployeeDataAccess();
                List<int> EmpIDList = empobj.GetEmployeeID();
                int i = 0;
                foreach (int EmpID in EmpIDList)
                {
                    EmployeeIDDropDownList.Items.Insert(i, new ListItem(EmpID.ToString()));
                    i++;
                }
                
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDetailsModel employee = new EmployeeDetailsModel()
                {
                    First_Name = First_NameTextBox.Text,
                    Last_Name = Last_NameTextBox.Text,
                    Email = EmailTextBox.Text,
                    Mobile_Number =Mobile_NumberTextBox.Text,
                    AlternateMobileNumber = AlternateMobileNumberTextBox.Text,
                    Address1 = Address1TextBox.Text,
                    Address2 = Address2TextBox.Text,
                    Current_Country = Current_CountryTextBox.Text,
                    Home_Country = Home_CountryTextBox.Text,
                    ZipCode = Convert.ToInt64(ZipCodeTextBox.Text),
                };
                EmployeeDataAccess employeedata = new EmployeeDataAccess();
                string emdata=employeedata.SaveEmployee(employee);
                if(emdata.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been saved successfully!');</script>");
                }
                
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Please enter the values: " +ex.Message);
               Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
           
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDetailsModel empeditmodels = new EmployeeDetailsModel()
                {
                    EmployeeID = Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    First_Name = First_NameTextBox.Text,
                    Last_Name = Last_NameTextBox.Text,
                    Email=EmailTextBox.Text,
                    Mobile_Number = Mobile_NumberTextBox.Text,
                    AlternateMobileNumber = AlternateMobileNumberTextBox.Text,
                    Address1 = Address1TextBox.Text,
                    Address2 = Address2TextBox.Text,
                    Current_Country = Current_CountryTextBox.Text,
                    Home_Country = Home_CountryTextBox.Text,
                    ZipCode = Convert.ToInt64(ZipCodeTextBox.Text),
                };
                EmployeeDataAccess empeditaccess = new EmployeeDataAccess();
               string emedit=empeditaccess.Editemployee(empeditmodels);
                if(emedit.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been updated successfully!');</script>");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Details have been updated: " + ex.Message);
                Response.Write("<script>alert('Please enter the values!"+ex.Message+"');</script>");
            }

        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            First_NameTextBox.Text = string.Empty;
            Last_NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            Mobile_NumberTextBox.Text = string.Empty;
            AlternateMobileNumberTextBox.Text = string.Empty;
            Address1TextBox.Text = string.Empty;
            Address2TextBox.Text = string.Empty;
            Current_CountryTextBox.Text = string.Empty;
            Home_CountryTextBox.Text = string.Empty;
            ZipCodeTextBox.Text = string.Empty;
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            EmployeeDetailsModel emdatamodels = new EmployeeDetailsModel();
            EmployeeDataAccess emdataaccess = new EmployeeDataAccess();
            emdatamodels = emdataaccess.GetEmployeeDetails(Convert.ToInt32(EmployeeIDDropDownList.SelectedValue));
            First_NameTextBox.Text = emdatamodels.First_Name;
            Last_NameTextBox.Text = emdatamodels.Last_Name;
            EmailTextBox.Text = emdatamodels.Email;
            Mobile_NumberTextBox.Text = emdatamodels.Mobile_Number;
            AlternateMobileNumberTextBox.Text = emdatamodels.AlternateMobileNumber;
            Address1TextBox.Text = emdatamodels.Address1;
            Address2TextBox.Text = emdatamodels.Address2;
            Current_CountryTextBox.Text = emdatamodels.Current_Country;
            Home_CountryTextBox.Text = emdatamodels.Home_Country;
            ZipCodeTextBox.Text = emdatamodels.ZipCode.ToString();

        }
    }
}