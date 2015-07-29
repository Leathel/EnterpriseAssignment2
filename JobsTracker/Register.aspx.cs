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

namespace JobTracker
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //When save is clicked
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Default UserStore constructor uses the default connection string named: DefaultConnection
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = txtUserName.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    //authenticating everything
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                    Response.Redirect("~/Admin/MainMenu.aspx");
                }
                else
                {
                    lblStatus.Text = result.Errors.FirstOrDefault();
                    lblStatus.CssClass = "label label-failure";
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