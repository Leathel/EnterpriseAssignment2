using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobsTracker
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            try
            {
                plhError.Visible = false;
                if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.User.IsInRole("Main User"))
                {
                    plhPublic.Visible = true;
                    plhPrivate.Visible = false;
                }
                else
                {
                    plhPublic.Visible = false;
                    plhPrivate.Visible = true;
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is HttpUnhandledException)
            {
                plhError.Visible = true;
                ErrorMsgTextBox.Text = "An error occurred on this page. Please verify your " +
                "information to resolve the issue.";
            }
            // Clear the error from the server.
            Server.ClearError();
        }
    }
}