using System;
using PapeD_Web.ServiceReference1;

namespace PapeD_Web
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usertype"] != null && !Session["Usertype"].Equals("MAN"))
            {
                //redirect to previous page
                Response.Redirect("Home.aspx");
            }

            //check if query string has a parsed productid
            if (!IsPostBack && Request.QueryString["prodId"] != null)
            {
                //get product id and convert it into integer.
                int prodId = int.Parse(Request.QueryString["prodId"]);

                //make use of the sevice to get product from database.
                using (var sc = new PaperDClient())
                {
                    //get product from database
                    dynamic product = sc.GetProduct(prodId);

                    if (product != null)
                    {
                        //display product information in the textfields.
                        txtName.Text = product.ProdName;
                        txtPrice.Text = product.ProdPrice.ToString("F2");
                        txtQuantity.Text = product.ProdQuantity.ToString();
                        txtDesc.Text = product.ProdDescription;
                        txtType.Text = product.ProdStatus;
                        txtCategory.Text = product.ProdCategory;
                        txtImg.Text = product.ProdImg;
                    }   
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["prodId"] != null)
            {
                //get product id
                int id = int.Parse(Request.QueryString["prodId"].ToString());

                //get all the information from the text fields.
                string name = txtName.Text;
                decimal price = Decimal.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                string description = txtDesc.Text;
                string image = txtImg.Text;
                string category = txtCategory.Text;
                string status = txtType.Text;

                //make use of the service to update product in the database.
                using (var sc = new PaperDClient())
                {
                    bool isUpdated = sc.addProduct(id, name, description, quantity, price, status, image, category);

                    if (isUpdated)
                    {
                        //succesfully updated product
                        lblMessage.Style.Value = "color : blue";
                        lblMessage.Text = "Product succesfully updated";
                    }
                    else
                    {
                        //unsuccesfully updated product
                        lblMessage.Style.Value = "color : green";
                        lblMessage.Text = "Could not update product, try again later";
                    }
                }
            }
            else
            {
                //get all the information from the text fields.
                string name = txtName.Text;
                decimal price = Decimal.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                string description = txtDesc.Text;
                string image = txtImg.Text;
                string category = txtCategory.Text;
                string status = txtType.Text;


                //make use of the service to add new product to the database.
                using (var sc = new PaperDClient())
                {
                    bool isAdded = sc.addProduct(0, name, description, quantity, price, status, image, category);

                    if (isAdded)
                    {
                        //succesfully added new product
                        lblMessage.Style.Value = "color : green";
                        lblMessage.Text = "Product succesfully added";
                    }
                    else
                    {
                        //unsuccesfully added new product
                        lblMessage.Style.Value = "color : red";
                        lblMessage.Text = "Could not add product, try again later";
                    }
                }
            }
        }
    }
}