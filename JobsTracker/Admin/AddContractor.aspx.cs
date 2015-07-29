using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JobsTracker.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
using System.IO;
namespace JobsTracker.Admin
{
    public partial class AddContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString.Count > 0)
            {
                getContractor();
            }
        }

        protected void getContractor()
        {
            try
            {
                Int32 ContractorID = Convert.ToInt32(Request.QueryString["ContractorID"]);

                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Contractor d = (from objs in db.Contractors where objs.ContractorID == ContractorID select objs).FirstOrDefault();

                    txtFirstName.Text = d.FirstName;
                    txtLastName.Text = d.LastName;
                    txtService.Text = d.Service;
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
                    Contractor Con = new Contractor();
                    Int32 ContractorID = 0;
                    if (Request.QueryString.Count > 0)
                    {
                        ContractorID = Convert.ToInt32(Request.QueryString["ContractorID"]);
                        //get the Employee from the entity ;D

                    }
                    Con.FirstName = txtFirstName.Text;
                    Con.LastName = txtLastName.Text;
                    Con.Service = txtService.Text;

                    if (ContractorID == 0)
                    {
                        db.Contractors.Add(Con);
                    }

                    db.SaveChanges();
                    Response.Redirect("~/admin/ShowContractors.aspx");
                }
            }
            catch (FileNotFoundException r)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.IO.IOException r)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (Exception r)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }

        }
    }
}