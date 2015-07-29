using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.IO;

namespace JobsTracker
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut();
                Response.Redirect("~/Login.aspx");
            }
            catch (FileNotFoundException xe)
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