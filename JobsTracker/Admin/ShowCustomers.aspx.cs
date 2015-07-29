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
    public partial class ShowCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCustomers();
            }
        }

        protected void getCustomers()
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    var Customers = from s in db.Customers
                                    select s;

                    grdShowCustomers.DataSource = Customers.ToList();
                    grdShowCustomers.DataBind();
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

        protected void grdShowCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //Store which row was clicked
                Int32 selectedRow = e.RowIndex;

                //get the selected sudent ID using the grids data key collection
                Int32 CustomerID = Convert.ToInt32(grdShowCustomers.DataKeys[selectedRow].Values["CustomerID"]);

                //use entity to find the object and remove it
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Customer c = (from objs in db.Customers where objs.CustomerID == CustomerID select objs).FirstOrDefault();

                    //now we need to do the delete
                    db.Customers.Remove(c);
                    db.SaveChanges();
                }
                //refresh the grid
                getCustomers();
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