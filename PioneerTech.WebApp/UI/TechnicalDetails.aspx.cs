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
                technicaldata.SaveTechnical(technicalmodel);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please enter the values: " + ex.Message);
            }
        }
    }
}