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
    public partial class ProjectDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjectDataAccess obj = new ProjectDataAccess();
                List<int> EmpIDList = obj.GetEmployeeID();
                int i = 0;
                foreach (int EmpID in EmpIDList)
                {
                    EmployeeIDDropDownList.Items.Insert(i, new ListItem(EmpID.ToString()));
                    i++;
                }
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void ProjectDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectDetailsModel projectmodel = new ProjectDetailsModel()
                {
                    EmployeeID = Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    Project_Name = Project_NameTextBox.Text,
                    Client_Name = Client_NameTextBox.Text,
                    Location = LocationTextBox.Text,
                    Roles = RolesTextBox.Text,
                };
                ProjectDataAccess projectdata = new ProjectDataAccess();
                string pjdata=projectdata.SaveProject(projectmodel);
                if(pjdata.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been saved successfully!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void EmployeeIDDropDownList_SelectedIndexchanged(object sender, EventArgs e)
        {
            ProjectDetailsModel projmodel = new ProjectDetailsModel();
            ProjectDataAccess projdata = new ProjectDataAccess();
            projmodel = projdata.GetProjectDetails(Convert.ToInt32(EmployeeIDDropDownList.SelectedValue));
            Project_NameTextBox.Text = projmodel.Project_Name;
            Client_NameTextBox.Text = projmodel.Client_Name;
            LocationTextBox.Text = projmodel.Location;
            RolesTextBox.Text = projmodel.Roles;
        }

        protected void ProjectDetailsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectDetailsModel pmodel = new ProjectDetailsModel()
                {
                    EmployeeID=Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    Project_Name=Project_NameTextBox.Text,
                    Client_Name=Client_NameTextBox.Text,
                    Location=LocationTextBox.Text,
                    Roles=RolesTextBox.Text,
                };
                ProjectDataAccess prdata = new ProjectDataAccess();
                string pdata=prdata.EditProject(pmodel);
                if(pdata.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been updated successfully!');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void ProjectDetailsClear_Click(object sender, EventArgs e)
        {
            Project_NameTextBox.Text = string.Empty;
            Client_NameTextBox.Text = string.Empty;
            LocationTextBox.Text = string.Empty;
            RolesTextBox.Text = string.Empty;
        }
    }
}