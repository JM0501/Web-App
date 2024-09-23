using System;
using System.Collections.Generic;
using PapeD_Web.ServiceReference1;
namespace PapeD_Web
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCartItems();
            }
        }

        private void loadCartItems()
        {
            string innerHtml = string.Empty;
            List<int> cart = Session["Cart"] as List<int>;

            if (cart != null && cart.Count > 0)
            {
                // Start the HTML table structure
                innerHtml += "<table border='1' cellpadding='5' cellspacing='0' style='width: 100%;'>";
                innerHtml += "<thead>";
                innerHtml += "<tr>";
                innerHtml += "<th>Product Image</th>";
                innerHtml += "<th>Product Name</th>";
                innerHtml += "<th>Quantity</th>";
                innerHtml += "<th>Price</th>";
                innerHtml += "<th>Total</th>";
                innerHtml += "</tr>";
                innerHtml += "</thead>";
                innerHtml += "<tbody>";

                int subTotal = 0;
                // Loop through each product in the cart
                foreach (int prodId in cart)
                {
                    // Use the service to get product details from the database
                    using (var sc = new PaperDClient())
                    {
                        dynamic product = sc.GetProduct(prodId);

                        // Generate HTML for each product row
                        innerHtml += "<tr>";

                        // Product Image
                        innerHtml += $"<td><img src='{product.ProdImg}' alt='{product.ProdName}' width='100' height='100' /></td>";

                        // Product Name
                        innerHtml += $"<td>{product.ProdName}</td>";

                        // Quantity
                        innerHtml += "<td>1</td>";

                        // Price
                        innerHtml += $"<td>{String.Format(new System.Globalization.CultureInfo("en-ZA"), "{0:C}", product.ProdPrice)}</td>";

                        // Total 
                        innerHtml += $"<td>{String.Format(new System.Globalization.CultureInfo("en-ZA"), "{0:C}", product.ProdPrice)}</td>";
                        
                        subTotal += product.ProdPrice;

                        innerHtml += "</tr>";
                    }
                }
                innerHtml += "<tr>";
                innerHtml += "<td colspan='4'><strong>Total</strong></td>"; // Label for total (spanning 3 columns)
                innerHtml += $"<td>{String.Format(new System.Globalization.CultureInfo("en-ZA"), "{0:C}", subTotal)}</td>";
                innerHtml += "</tr>";

                innerHtml += "</tbody>";
                innerHtml += "</table>";
            }
            else
            {
                // If the cart is empty
                innerHtml += "<p>Your cart is empty.</p>";
            }

            // Display the generated HTML (assuming you have a placeholder to display this)
            cartLiteral.Text = innerHtml;
        }
    }
}