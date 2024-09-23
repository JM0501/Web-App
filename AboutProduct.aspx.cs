using System;
using System.Collections.Generic;
using PapeD_Web.ServiceReference1;


namespace PapeD_Web
{
    public partial class AboutProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAboutProduct();
            }

            //add to cart
            if (!IsPostBack && Request.QueryString["prodId"] != null)
            {
                int prodId = Convert.ToInt32(Request.QueryString["prodId"]);

                // Get the list of Cart from session
                List<int> cart = Session["Cart"] as List<int>;

                // Initialize a new cart if necessary
                if (cart == null)
                {
                    cart = new List<int>();
                }

                // Add the product ID to the cart
                cart.Add(prodId);

                // Store the updated cart back in the session
                Session["Cart"] = cart;
            }
        }

        //function to dynamically populate about clicked product.
        private void showAboutProduct()
        {
            //request product id from the query string.
            string productId = string.Empty;

            if (Request.QueryString["prodId"] != null)
            {
                productId = Request.QueryString["prodId"].ToString();
                if (productId != null)
                {
                    int id = int.Parse(productId);
                    //use the service to get specified product.
                    using (var sc = new PaperDClient())
                    {
                        dynamic product = sc.GetProduct(id);

                        //generate html to display product.
                        string innerHtml = string.Empty;

                        //<!-- Selected Image -->
                        innerHtml += "<div class='col - lg - 5 order - lg - 2 order - 1'>";
                        innerHtml += "<div class='image_selected'>";
                        innerHtml += $"<img src = {product.ProdImg} alt={product.ProdName}>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";

                        //<!-- Description -->
                        innerHtml += "<div class='col-lg-5 order-3'>";
                        innerHtml += "<div class='product_description'>";
                        innerHtml += $"<div class='product_category'>{product.ProdCategory}</div>";
                        innerHtml += $"<div class='product_name'>{product.ProdName}</div>";
                        innerHtml += "<div class='rating_r rating_r_4 product_rating'><i></i><i></i><i></i><i></i><i></i></div>";
                        innerHtml += "<div class='product_text'>";
                        innerHtml += $"<p>{product.ProdDescription}</p>";
                        innerHtml += "</div>";
                        innerHtml += "<div class='order_info d-flex flex - row'>";
                        innerHtml += "<form action = '#'>";
                        innerHtml += "<div class='clearfix' style='z - index: 1000; '>";

                        // <!-- Product Quantity -->
                        innerHtml += "<div class='product_quantity clearfix'>";
                        innerHtml += "<span>Quantity: </span>";
                        innerHtml += "<input id = 'quantity_input' type='text'  'value='1'>";
                        innerHtml += "<div class='quantity_buttons'>";
                        innerHtml += "<div id = 'quantity_inc_button' class='quantity_inc quantity_control'><i class='fas fa-chevron - up'></i></div>";
                        innerHtml += "<div id = 'quantity_dec_button' class='quantity_dec quantity_control'><i class='fas fa-chevron - down'></i></div>";
                        innerHtml += " </div>";
                        innerHtml += " </div>";

                        //<!-- Product Color -->
                        innerHtml += "<ul class='product_color'>";
                        innerHtml += "<li>";
                        innerHtml += "<span>Color: </span>";
                        innerHtml += "<div class='color_mark_container'>";
                        innerHtml += "<div id = 'selected_color' class='color_mark'></div>";
                        innerHtml += "</div>";
                        innerHtml += " <div class='color_dropdown_button'><i class='fas fa-chevron - down'></i></div>";

                        innerHtml += "<ul class='color_list'>";
                        innerHtml += "<li>";
                        innerHtml += "<div class='color_mark' style='background: #999999;'></div>";
                        innerHtml += "</li>";
                        innerHtml += "<li>";
                        innerHtml += "<div class='color_mark' style='background: #b19c83;'></div>";
                        innerHtml += "</li>";
                        innerHtml += "<li>";
                        innerHtml += "<div class='color_mark' style='background: #000000;'></div>";
                        innerHtml += "</li>";
                        innerHtml += "</ul>";
                        innerHtml += "</li>";
                        innerHtml += "</ul>";
                        innerHtml += "</div>";

                        //<!-- Product price -->
                        innerHtml += $"<div class='product_price'>R{product.ProdPrice.ToString("F2")}</div>";

                        //only show the add to cart button if there's a logged in user.
                        if (Session["Usertype"] != null)
                        {
                            //only show the cart button to  a logged in user.
                            innerHtml += "<div class='button_container'>";
                            innerHtml += $"<a href='AboutProduct.aspx?prodId={product.ProdId}'><button class='button cart_button'>Add to Cart</button></a>";
                            innerHtml += "<div class='product_fav'><i class='fas fa-heart'></i></div>";
                            innerHtml += "</div>";

                        }
                       
                        if (Session["Usertype"] != null && Session["Usertype"].Equals("MAN"))
                        {
                            //also show the edit button
                            innerHtml += "<div class='button_container'>";
                            innerHtml += $"<a href='AddProduct.aspx?prodId={product.ProdId}' class='button cart_button'>Edit Product</a>";
                            innerHtml += "<div class='product_fav'><i class='fas fa-heart'></i></div>";
                            innerHtml += "</div>";
                        }

                        innerHtml += "</form>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";

                        //update the text literal.
                        aboutLiteral.Text = innerHtml;
                    }
                }
                else
                {
                    aboutLiteral.Text = "<p><h3>Go home and select product</h3></p>";
                }
            }
            else
            {
             aboutLiteral.Text = "<p><h1 style='color: blue'>Added to cart</h1></p>";
            }
        }  
    }
}