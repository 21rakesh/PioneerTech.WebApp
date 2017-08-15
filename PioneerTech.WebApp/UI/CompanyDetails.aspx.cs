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
    public partial class CompanyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            CompanyDataAccess obj = new CompanyDataAccess();
            List<int> EmpIDList = obj.GetEmployeeID();
            int i = 0;
            foreach (int EmpID in EmpIDList)
            {
                EmployeeIDDropDownList.Items.Insert(i, new ListItem(EmpID.ToString()));
                i++;
            }
            }
        }

        protected void CompanyDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyDetailsModel companymodel = new CompanyDetailsModel()
                {
                    Employer_Name=Employer_NameTextBox.Text,
                    //EmployeeID=Convert.ToInt32(EmployeeIDDropDownList.DataTextField),
                    Contact_Number=Convert.ToInt64(Contact_NumberTextBox.Text),
                    Location=LocationTextBox.Text,
                    Website=WebsiteTextBox.Text,
                };
                CompanyDataAccess companydata = new CompanyDataAccess();
                companydata.SaveCompany(companymodel);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter the values: " + ex.Message);
            }
        }

        protected void CompanyDetailsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyDetailsModel model = new CompanyDetailsModel()
                {

                    Employer_Name = Employer_NameTextBox.Text,
                    EmployeeID = Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    Contact_Number = Convert.ToInt64(Contact_NumberTextBox.Text),
                    Location = LocationTextBox.Text,
                    Website = WebsiteTextBox.Text,
                };
                CompanyDataAccess access = new CompanyDataAccess();
                access.EditCompany(model);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter the values: " + ex.Message);
            }
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyDetailsModel companymodel = new CompanyDetailsModel();
            CompanyDataAccess companyaccess = new CompanyDataAccess();
            companymodel = companyaccess.GetCompanyDetails(Convert.ToInt32(EmployeeIDDropDownList.SelectedValue));
            Employer_NameTextBox.Text = companymodel.Employer_Name;
            Contact_NumberTextBox.Text = companymodel.Contact_Number.ToString();
            LocationTextBox.Text = companymodel.Location;
            WebsiteTextBox.Text = companymodel.Website;

       }

        protected void CompanyDetailsClear_Click(object sender, EventArgs e)
        {
            Employer_NameTextBox.Text = string.Empty;
            Contact_NumberTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            WebsiteTextBox.Text = string.Empty;
        }
    }
}