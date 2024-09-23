using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashPass;
using PapeD_Web.ServiceReference1;

namespace PapeD_Web
{
    public partial class Login : System.Web.UI.Page
    {
        PaperDClient client = new PaperDClient();
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var loguser = client.Login(email.Value, Secrecy.HashPassword(password.Value));

            if (loguser != null)
            {
                Session["Usertype"] = loguser.UserType;
                Session["UserID"] = loguser.Id;
                Session["username"] = loguser.Name;
                Response.Redirect("Home.aspx");
            }
            else
            {
                error.Text = "Invalid username or password.";
            }
        }
    }
}