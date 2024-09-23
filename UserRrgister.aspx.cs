using System;
using PapeD_Web.ServiceReference1;
using HashPass;

namespace PapeD_Web
{
    public partial class UserRrgister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"] != null && Session["UserType"].ToString().Equals("MAN"))
                {
                    // Show the container
                    userTypeContainer.Style["display"] = "block"; 
                }
                else
                {
                    // Hide the container
                    userTypeContainer.Style["display"] = "none";
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //get input from user.
            string name = txtUsername.Text;
            string Email = txtEmail.Text;
            string password = txtPassword.Text;
            string usertype = string.Empty;

            //check if its the manager registering or its a Customer.
            if (Session["Usertype"] != null && Session["Usertype"].Equals("MAN"))
            {
                usertype = txtUserType.Text;
            }
            else
            {
                usertype = "CUS";
            }

            //hash the user password.
            string hashedPass = Secrecy.HashPassword(password);

            //make use of the services
            using (var sc = new PaperDClient())
            {
                bool isReg = false;
                //try registering a user.
                 isReg = sc.RegisterUser(name, Email, hashedPass, usertype);

                if (isReg)
                {
                    //Succesful login, redirect to Login.aspx
                    Response.Redirect("Login.aspx");
                }
                else 
                {
                    lblMessage.Text = $"Account with given email already exist.";
                }
            }
        }

    }
}