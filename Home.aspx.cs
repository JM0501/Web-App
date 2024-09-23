using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using PapeD_Web.ServiceReference1;

namespace PapeD_Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Display products when page loads.
            if (!IsPostBack)
            {
                //populate my literals
                showDOTW();
                showFeatured();
                showSale();
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

                    // Redirect to the same page
                    Response.Redirect("Home.aspx");
            }
        }

        //function to show all the Deals Of The Week products
        private void showDOTW()
        {
            // Placeholder to store generated HTML code.
            string innerHtml = string.Empty;

            // Make use of the service
            using (var sc = new PaperDClient())
            {
                // Get Deals of the Week products.
                dynamic products = sc.getProductsByStatus("DOTW");

                if (products != null)
                {
                    // Iterate through each product.
                    foreach (var product in products)
                    {
                        innerHtml += "<div class='owl-item deals_item'>";
                        innerHtml += $"<div class='deals_image'><a href='AboutProduct.aspx?prodId={product.ProdId}'><img src='{product.ProdImg}' alt=''></a></div>";
                        innerHtml += "<div class='deals_content'>";

                        // First info line (category and price_a)
                        innerHtml += "<div class='deals_info_line d-flex flex-row justify-content-start'>";
                        innerHtml += $"<div class='deals_item_category'>>{product.ProdCategory}</div>";
                        innerHtml += $"<div class='deals_item_price_a ml-auto'>R{product.ProdPrice.ToString("F2")}</div>";
                        innerHtml += "</div>";

                        // Second info line (name and price)
                        innerHtml += "<div class='deals_info_line d-flex flex-row justify-content-start'>";
                        innerHtml += $"<div class='deals_item_name'><a href='AboutProduct.aspx?prodId={product.ProdId}'>{product.ProdName}</a></div>";

                        //correctly format the product discounted price.
                        if (product.ProdDiscountPrice == null)
                        {
                            product.ProdDiscountPrice = 0000;
                        }
                        else
                        {
                            product.ProdDiscountPrice = product.ProdDiscountPrice;
                        }

                        innerHtml += $"<div class='deals_item_price ml-auto'>R{product.ProdDiscountPrice.ToString("F2")}</div>";
                        innerHtml += "</div>";

                        // Available stock info
                        innerHtml += "<div class='available'>";
                        innerHtml += "<div class='available_line d-flex flex-row justify-content-start'>";
                        innerHtml += $"<div class='available_title'>Available: <span>{product.ProdQuantity}</span></div>";
                        innerHtml += $"<div class='sold_title ml-auto'>Already sold: <span>{20}</span></div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";

                        // Timer section
                        innerHtml += "<div class='deals_timer d-flex flex-row align-items-center justify-content-start'>";
                        innerHtml += "<div class='deals_timer_title_container'>";
                        innerHtml += "<div class='deals_timer_title'>Hurry Up</div>";
                        innerHtml += "<div class='deals_timer_subtitle'>Offer ends in:</div>";
                        innerHtml += "</div>";

                        innerHtml += "<div class='deals_timer_content ml-auto'>";
                        innerHtml += "<div class='deals_timer_box clearfix' data-target-time=''>";

                        // Timer hours
                        innerHtml += "<div class='deals_timer_unit'>";
                        innerHtml += "<div id='deals_timer1_hr' class='deals_timer_hr'></div>";
                        innerHtml += "<span>hours</span>";
                        innerHtml += "</div>";

                        // Timer minutes
                        innerHtml += "<div class='deals_timer_unit'>";
                        innerHtml += "<div id='deals_timer1_min' class='deals_timer_min'></div>";
                        innerHtml += "<span>mins</span>";
                        innerHtml += "</div>";

                        // Timer seconds
                        innerHtml += "<div class='deals_timer_unit'>";
                        innerHtml += "<div id='deals_timer1_sec' class='deals_timer_sec'></div>";
                        innerHtml += "<span>secs</span>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                        innerHtml += "</div>";
                    }
                }
                else
                {
                    innerHtml += "<p>Out Of Stock</p>";
                }
            }

            // Update the literal control with the generated HTML.
            dealsLiteral.Text = innerHtml;
        }

        //function to display all the Featured products
        private void showFeatured()
        {
            // Use helper function to get featured products.
            string innerHtml = innerHTML("Featured");
            // Update the literal control with the generated HTML.
            featuredLiteral.Text = innerHtml;
        }
        //function to display all on sale products
        private void showSale()
        {
            //return generated html code, with sales products
            string innerHtml = innerHTML("Sale");

            //update literal
            saleLiteral.Text = innerHtml;
        }

        //helper function to return string of tabbed products based on their status
        private string innerHTML(string prodStatus)
        {
            // Placeholder to store generated HTML code.
            string innerHtml = string.Empty;
            // Make use of the service to get the products of the given prodStatus.
            using (var sc = new PaperDClient())
            {
                // Get Featured products.
                dynamic products = sc.getProductsByStatus(prodStatus);

                if (products != null)
                {
                    // Iterate through each product.
                    foreach (var product in products)
                    {
                        innerHtml += "<div class='featured_slider_item'>";
                        innerHtml += "<div class='border_active'></div>";
                        innerHtml += "<div class='product_item discount d-flex flex-column align-items-center justify-content-center text-center'>";

                        // Product image
                        innerHtml += $"<div class='deals_image'><a href='AboutProduct.aspx?prodId={product.ProdId}'><img src='{product.ProdImg}' alt=''></a></div>";

                        // Product content
                        innerHtml += "<div class='product_content'>";

                        // Correctly format the product discounted price
                        if (product.ProdDiscountPrice != null)
                        {
                            //product.ProdDiscountPrice = 0.00M;
                            innerHtml += $"<div class='product_price discount'>R{product.ProdDiscountPrice.ToString("F2")}<span style='text-decoration: line-through;'> R{product.ProdPrice.ToString("F2")}</span></div>";
                        }
                        else
                        {
                            innerHtml += $"<div class='product_price discount'><span>R{product.ProdPrice.ToString("F2")}</span></div>";
                        }

                        // Product name
                        innerHtml += $"<div class='product_name'><div><a href='AboutProduct.aspx?prodId={product.ProdId}'>{product.ProdName}</a></div></div>";

                        // Product extras
                        innerHtml += "<div class='product_extras'>";

                        // Product colors
                        innerHtml += "<div class='product_color'>";
                        innerHtml += "<input type='radio' checked name='product_color' style='background:#b19c83'>";
                        innerHtml += "<input type='radio' name='product_color' style='background:#000000'>";
                        innerHtml += "<input type='radio' name='product_color' style='background:#999999'>";
                        innerHtml += "</div>";

                        // Add to Cart button
                        if (Session["Usertype"] != null && (Session["Usertype"].Equals("CUS") || Session["Usertype"].Equals("MAN")))
                        {
                            innerHtml += $"<a href='Home.aspx?prodId={product.ProdId}'><button class='product_cart_button'>Add to Cart</button></a>";
                        }

                        //if theres a logged in manager, show the edit button to allow manager to edit a product
                        if (Session["Usertype"] != null && Session["Usertype"].Equals("MAN"))
                        {
                            innerHtml += $"<a href='AddProduct.aspx?prodId={product.ProdId}'><button class='product_cart_button'>Edit</button></a>";
                        }

                        //close divs.
                        innerHtml += "</div>";
                        innerHtml += "</div>";

                        // Favorite icon
                        innerHtml += "<div class='product_fav'><i class='fas fa-heart'></i></div>";

                        // Product marks
                        innerHtml += "<ul class='product_marks'>";
                        innerHtml += "<li class='product_mark product_new'>new</li>";
                        innerHtml += "</ul>";

                        innerHtml += "</div>";
                        innerHtml += "</div>";
                    }
                }
                else
                {
                    innerHtml += $"<p>No {prodStatus} products available.</p>";
                }
            }
            return innerHtml;
        } 
    }
}
