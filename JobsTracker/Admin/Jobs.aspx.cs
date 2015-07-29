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
    public partial class Jobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getJobs();
            }
        }
        protected void getJobs()
        {
            try
            {
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    //query the Jobs table using entity
                    var Jobs = from g in db.Jobs
                               select g;

                    grdJobs.DataSource = Jobs.ToList();
                    grdJobs.DataBind();

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

        protected void grdJobs_RowDeleting(object sender, GridViewDeleteEventArgs g)
        {
            try
            {
                //Store which row was clicked
                Int32 selectedRow = g.RowIndex;

                //get the selected sudent ID using the grids data key collection
                Int32 JobID = Convert.ToInt32(grdJobs.DataKeys[selectedRow].Values["JobID"]);

                //use entity to find the object and remove it
                using (ErmagerdEntities db = new ErmagerdEntities())
                {
                    Job j = (from objs in db.Jobs where objs.JobID == JobID select objs).FirstOrDefault();

                    //now we need to do the delete
                    db.Jobs.Remove(j);
                    db.SaveChanges();
                }
                //refresh the grid
                getJobs();
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
    }
}