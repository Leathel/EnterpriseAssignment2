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
    public partial class AddJob : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCustomers();
            }

        }
        //Populate the dropdown for the customers
        protected void GetCustomers()
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    var customer = (from d in db.Customers
                                    orderby d.CustomerID
                                    select d);

                    ddlCustomerSearch.DataSource = customer.ToList();
                    ddlCustomerSearch.DataBind();
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

                    Job J = new Job();
                    Int32 JobID = 0;
                    if (Request.QueryString.Count > 0)
                    {
                        JobID = Convert.ToInt32(Request.QueryString["JobID"]);
                        //get the Job from the entity ;D

                    }
                    J.CustomerID = Convert.ToInt32(ddlCustomerSearch.SelectedValue.ToString());
                    J.Cost = Convert.ToInt32(txtCost.Text);
                    J.MaterialCost = Convert.ToInt32(txtMaterialCost.Text);
                    J.JobDate = Convert.ToDateTime(txtJobDate.Text);
                    J.Description = txtDescription.Text;

                    if (JobID == 0)
                    {
                        db.Jobs.Add(J);
                    }

                    db.SaveChanges();
                    Response.Redirect("~/admin/Jobs.aspx");
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

        protected void ddlCustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}