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
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getEmployees();
            }
        }
        protected void getEmployees()
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    //query the Employees table using entity
                    var Employees = from s in db.Employees
                                    select s;

                    grdEmployees.DataSource = Employees.ToList();
                    grdEmployees.DataBind();
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

        protected void grdEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //Store which row was clicked
                Int32 selectedRow = e.RowIndex;

                //get the selected sudent ID using the grids data key collection
                Int32 EmployeeID = Convert.ToInt32(grdEmployees.DataKeys[selectedRow].Values["EmployeeID"]);

                //use entity to find the object and remove it
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Employee s = (from objs in db.Employees where objs.EmployeeID == EmployeeID select objs).FirstOrDefault();

                    //now we need to do the delete
                    db.Employees.Remove(s);
                    db.SaveChanges();
                }
                //refresh the grid
                getEmployees();
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