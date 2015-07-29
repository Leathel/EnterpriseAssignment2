using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JobsTracker.Models;
using System.Web.ModelBinding;
using System.IO;

namespace JobsTracker.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if save wasnt clicked and we have a Employee ID in the URL
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                GetEmployee();
            }
        }

        protected void GetEmployee()
        {
            try
            {
                //populate form for edit
                //get the ID
                Int32 EmployeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);
                //connec tot he db using Entity
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    //populate from a Employee instance with the Employee ID from the URL params
                    Employee s = (from objs in db.Employees where objs.EmployeeID == EmployeeID select objs).FirstOrDefault();

                    //mpa the Employee properties from the form controls

                    txtLastName.Text = s.LastName;
                    txtFirstName.Text = s.FirstName;
                    txtHireDate.Text = s.HireDate.ToShortDateString();


                    //enrollments - this code goes in the same method that populates the Employee form but below the existing code that's already in GetEmployee()               
                    //var objE = (from en in db.Enrollments
                    //            join c in db.Courses on en.CourseID equals c.CourseID
                    //            join d in db.Departments on c.DepartmentID equals d.DepartmentID
                    //            where en.EmployeeID == EmployeeID
                    //            select new { en.EnrollmentID, en.Grade, c.Title, d.Name });

                    //grdCourses.DataSource = objE.ToList();
                    //grdCourses.DataBind();
                }

            }
            catch (FileNotFoundException e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.IO.IOException e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (Exception e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
        }
        //When save is clicked
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Employee Emp = new Employee();
                    Int32 EmployeeID = 0;
                    if (Request.QueryString.Count > 0)
                    {
                        EmployeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);
                        //get the Employee from the entity ;D

                    }
                    Emp.LastName = txtLastName.Text;
                    Emp.FirstName = txtFirstName.Text;
                    Emp.HireDate = Convert.ToDateTime(txtHireDate.Text);

                    if (EmployeeID == 0)
                    {
                        db.Employees.Add(Emp);
                    }

                    db.SaveChanges();
                    Response.Redirect("~/admin/Employees.aspx");
                }
            }
            catch (FileNotFoundException ex)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.IO.IOException ex)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (Exception ex)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }

        }
    }
}