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
    public partial class TechnicalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TechnicalDataAccess obj = new TechnicalDataAccess();
                List<int> EmpIDList = obj.GetEmployeeID();
                int i = 0;
                foreach (int EmpID in EmpIDList)
                {
                    EmployeeIDDropDownList.Items.Insert(i, new ListItem(EmpID.ToString()));
                    i++;
                }
            }
        }

        protected void TechnicalDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                TechnicalDetailsModels technicalmodel = new TechnicalDetailsModels()
                {
                    UI = UITextBox.Text,
                    Programming_Languages = Programming_LanguagesTextBox.Text,
                    ORM_Technologies = ORM_TechnologiesTextBox.Text,
                    Databases = DatabasesTextBox.Text,
                };
                TechnicalDataAccess technicaldata = new TechnicalDataAccess();
                string techdata=technicaldata.SaveTechnical(technicalmodel);
                if(techdata.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been saved successfully!');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void TechnicalDetailsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                TechnicalDetailsModels tmodels = new TechnicalDetailsModels()
                {
                    EmployeeID=Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    UI = UITextBox.Text,
                    Programming_Languages=Programming_LanguagesTextBox.Text,
                    ORM_Technologies=ORM_TechnologiesTextBox.Text,
                    Databases=DatabasesTextBox.Text,
                };
                TechnicalDataAccess taccess = new TechnicalDataAccess();
                string tdata=taccess.EditTechnical(tmodels);
                if(tdata.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been updated successfully!');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void TechnicalDetailsClear_Click(object sender, EventArgs e)
        {
            UITextBox.Text = string.Empty;
            Programming_LanguagesTextBox.Text = string.Empty;
            ORM_TechnologiesTextBox.Text = string.Empty;
            DatabasesTextBox.Text = string.Empty;
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TechnicalDetailsModels technicalmodel = new TechnicalDetailsModels();
            TechnicalDataAccess technicaldata = new TechnicalDataAccess();
            technicalmodel = technicaldata.GetTechnicalDetails(Convert.ToInt32(EmployeeIDDropDownList.SelectedValue));
            UITextBox.Text = technicalmodel.UI;
            Programming_LanguagesTextBox.Text = technicalmodel.Programming_Languages;
            ORM_TechnologiesTextBox.Text = technicalmodel.ORM_Technologies;
            DatabasesTextBox.Text = technicalmodel.Databases;
        }
    }
}