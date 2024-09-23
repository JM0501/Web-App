using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapeD_Web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserType"] = null;
            Session["UserID"] = null;
            Session["username"] = null;
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}