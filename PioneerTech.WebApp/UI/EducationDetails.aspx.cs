﻿using PioneerDataAccess;
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
            if (!IsPostBack)
            {
                EducationDataAccess obj = new EducationDataAccess();
                List<int> EmpIDList = obj.GetEmployeeID();
                int i = 0;
                foreach (int EmpID in EmpIDList)
                {
                    EmployeeIDDropDownList.Items.Insert(i, new ListItem(EmpID.ToString(), EmpID.ToString()));
                    i++;
                }
            }
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
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
                string edsave=educationdata.SaveEducation(education);
                if(edsave.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been saved successfully!');</script>");
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Please enter the values: " + ex.Message);
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void EmployeeIDDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EducationDetailsModel educationmodel = new EducationDetailsModel();
            EducationDataAccess educationaccess = new EducationDataAccess();
            educationmodel=educationaccess.GetEducationDetails(Convert.ToInt32(EmployeeIDDropDownList.SelectedValue));
            CourseTypeTextBox.Text = educationmodel.CourseType;
            CourseSpecialisationTextBox.Text = educationmodel.CourseSpecialisation;
            YearOfPassTextBox.Text = educationmodel.YearOfPass.ToString();
        }

        protected void EducationalDetailsEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EducationDetailsModel edmodel = new EducationDetailsModel()
                {

                    CourseType = CourseTypeTextBox.Text,
                    EmployeeID = Convert.ToInt32(EmployeeIDDropDownList.SelectedValue),
                    CourseSpecialisation =CourseSpecialisationTextBox.Text,
                    YearOfPass=Convert.ToInt32(YearOfPassTextBox.Text),
                };
                EducationDataAccess cmpaccess = new EducationDataAccess();
                string ededit=cmpaccess.Editeducation(edmodel);
                if(ededit.Equals("success"))
                {
                    Response.Write("<script>alert('Details have been updated successfully!');</script>");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Please enter the values: " + ex.Message);
                Response.Write("<script>alert('Please enter the values!" + ex.Message + "');</script>");
            }
        }

        protected void EducationalDetailsClear_Click(object sender, EventArgs e)
        {
            CourseTypeTextBox.Text = String.Empty;
            CourseSpecialisationTextBox.Text = string.Empty;
            YearOfPassTextBox.Text = string.Empty;
        }
    }
}