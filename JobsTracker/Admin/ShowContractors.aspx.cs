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
    public partial class ShowContractors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getContractors();
            }
        }

        protected void getContractors()
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    //query the Jobs table using entity
                    var Contractors = from c in db.Contractors
                                      select c;

                    grdContractors.DataSource = Contractors.ToList();
                    grdContractors.DataBind();

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

        protected void grdContractors_RowDeleting(object sender, GridViewDeleteEventArgs g)
        {
            try
            {
                //Store which row was clicked
                Int32 selectedRow = g.RowIndex;

                //get the selected sudent ID using the grids data key collection
                Int32 ContractorID = Convert.ToInt32(grdContractors.DataKeys[selectedRow].Values["ContractorID"]);

                //use entity to find the object and remove it
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Contractor j = (from objs in db.Contractors where objs.ContractorID == ContractorID select objs).FirstOrDefault();

                    //now we need to do the delete
                    db.Contractors.Remove(j);
                    db.SaveChanges();
                }
                //refresh the grid
                getContractors();
            }
            catch (FileNotFoundException e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch (System.IO.IOException e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            catch(Exception e)
            {
                Server.Transfer("/ErrorPage.aspx", true);
            }
            
            
        }
    }
}