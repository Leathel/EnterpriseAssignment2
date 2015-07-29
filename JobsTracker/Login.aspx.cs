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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //When save is clicked
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(txtUserName.Text, txtPassword.Text);

                if (user != null)
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                    Response.Redirect("~/admin/MainMenu.aspx");
                }
                else
                {
                    lblStatus.Text = "Invalid username or password.";

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