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
           
        }

        protected void ProjectDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProjectDetailsModel projectmodel = new ProjectDetailsModel()
                {
                    EmployeeID = Convert.ToInt32(EmployeeIDTextBox.Text),
                    Project_Name = Project_NameTextBox.Text,
                    Client_Name = Client_NameTextBox.Text,
                    Location = LocationTextBox.Text,
                    Roles = RolesTextBox.Text,
                };
                ProjectDataAccess projectdata = new ProjectDataAccess();
                projectdata.SaveProject(projectmodel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter the values: " + ex.Message);
            }
        }
    }
}