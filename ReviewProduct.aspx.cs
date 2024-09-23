using System;
using System.Collections.Generic;
using PapeD_Web.ServiceReference1;

namespace PapeD_Web
{
    public partial class ReviewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Session["UserID"] == null)
            {
                // Redirect to login page
                Response.Redirect("Login.aspx");
                return;
            }

            // Get the logged-in user's ID
            int userId = Convert.ToInt32(Session["UserID"]);
            int productId = Convert.ToInt32(Request.QueryString["prodId"]);

            if (!IsPostBack)
            {
                // Check if the user has reviewed this product before
                if (HasUserReviewedProduct(userId, productId))
                {
                    // Load existing review for editing
                    //int revId = int.Parse(Session["revID"].ToString());
                    int revStars = int.Parse(Session["revStars"].ToString());
                    string revText = Session["Review"].ToString();

                    txtMessage.Text = revText;
                    txtStars.Text = revStars.ToString();

                    lblMessage.Text = "Edit above review and submit";
                }
                else
                {
                    // Show a message for new review
                    lblMessage.Text = "Write a new review for this product.";
                }
            }
        }

        protected void btnSubmitReview_Click(object sender, EventArgs e)
        {
            // Retrieve the input values from the form
            string message = txtMessage.Text;
            int stars = int.Parse(txtStars.Text);

            //get UserId & productid
            int userId = int.Parse(Session["UserID"].ToString());
            int productId = int.Parse(Request.QueryString["prodId"]);
            //make use of the service
            using (var sc = new PaperDClient())
            {
                bool isReviewAdded = sc.addReview(productId,userId,stars,message);

                if (isReviewAdded)
                {
                    lblMessage.Text = "Your review has been submitted!";

                    //redirect to previous page
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    lblMessage.Text = "There was an error submitting your review.";
                }
            }
            
        }

            //helper function
            private bool HasUserReviewedProduct(int userId, int productId)
        {
            bool reviewed = false;

            //make use of the service
            using (var sc = new PaperDClient())
            {
                //get review
                dynamic review = sc.retrievReview(userId, productId);

                if (review != null)
                {
                    Session["revID"] = review.RevId.ToString();
                    Session["revStars"] = review.RevStars.ToString();
                    Session["Review"] = review.Review;
                    reviewed = true;
                }
                else
                {
                    //user hasn't reviewed
                    reviewed = false;
                }
            }

            return reviewed;
        }
    }
}