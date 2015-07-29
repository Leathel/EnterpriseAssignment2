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
    public partial class AddCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                getCustomer();
            }
        }

        protected void getCustomer()
        {
            try
            {
                Int32 CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);

                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Customer d = (from objs in db.Customers where objs.CustomerID == CustomerID select objs).FirstOrDefault();

                    txtName.Text = d.Name;
                    txtAddress.Text = d.Address;
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
                    Customer Cus = new Customer();
                    Int32 CustomerID = 0;
                    if (Request.QueryString.Count > 0)
                    {
                        CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
                        //get the Employee from the entity ;D

                    }
                    Cus.Name = txtName.Text;
                    Cus.Address = txtAddress.Text;

                    if (CustomerID == 0)
                    {
                        db.Customers.Add(Cus);
                    }

                    db.SaveChanges();
                    Response.Redirect("~/admin/ShowCustomers.aspx");
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