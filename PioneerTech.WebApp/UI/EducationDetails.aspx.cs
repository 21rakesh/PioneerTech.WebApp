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
    public partial class EducationalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EducationalDetailsSave_Click(object sender, EventArgs e)
        {
            try
            {
                EducationDetailsModel education = new EducationDetailsModel()
                {
                    CourseType=CourseTypeTextBox.Text,
                    CourseSpecialisation=CourseTypeTextBox.Text,
                    YearOfPass=Convert.ToInt32(YearOfPassTextBox.Text),
                };
                EducationDataAccess educationdata = new EducationDataAccess();
                educationdata.SaveEducation(education);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter the values: " + ex.Message);
            }
        }
    }
}