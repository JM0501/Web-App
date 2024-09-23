using System;
using System.Collections.Generic;
using System.Linq;

namespace PaperD_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PaperD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PaperD.svc or PaperD.svc.cs at the Solution Explorer and start debugging.
    public class PaperD : IPaperD
    {
        //database context.
        PaperDDataContext db = new PaperDDataContext();

        //function to retrieve existing Review.
        public ProdReview retrievReview(int userid, int productId)
        {
            //return entire Product Review, otherwise null.
            return db.ProdReviews.Where(pr => pr.UserId == userid && pr.ProdId == productId).FirstOrDefault();
        }
        //Function to edit existing product review
        public bool EditReview(int revId, int stars, string review)
        {
            try
            {
                using (PaperDDataContext db = new PaperDDataContext())
                {
                    // Fetch the existing review from the database
                    var existingReview = db.ProdReviews.SingleOrDefault(r => r.RevId == revId);
                    if (existingReview != null)
                    {
                        // Update the properties
                        existingReview.RevStars = stars;
                        existingReview.Review = review;

                        // Submit changes to the database
                        db.SubmitChanges();
                        // Success
                        return true;
                    }
                    else
                    {
                        // Review not found
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Failure
                return false;
            }
        }
        //function to add new review.
        public bool addReview(int prodId, int userId, int stars, string review)
        {
            try
            { 
                    // Create a new review object
                    var newReview = new ProdReview
                    {
                        UserId = userId,
                        ProdId = prodId,
                        // Set the current date
                        RevDate = DateTime.Now, 
                        RevStars = stars,
                        Review = review
                    };

                    // Insert the new review into the context
                    db.ProdReviews.InsertOnSubmit(newReview);

                    // Submit changes to the database
                    db.SubmitChanges();

                // Success
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Failure
                return false; 
            }
        }

        //function to either enter new product in database or update existing product information.
        public bool addProduct(int prodId, string name, string description, int quantity, decimal price, string status, string image,string category)
        {
            bool isAdded = false;
            try
            {
                // Existing product
                if (prodId > 0)
                    {
                        // Find the existing product
                        var existingProduct = db.Products.SingleOrDefault(p => p.ProdId == prodId);
                        if (existingProduct != null)
                        {
                            // Update existing product properties
                            existingProduct.ProdName = name;
                            existingProduct.ProdDescription = description;
                            existingProduct.ProdQuantity = quantity;
                            existingProduct.ProdPrice = price;
                            existingProduct.ProdStatus = status;
                            existingProduct.ProdImg = image;
                            existingProduct.ProdCategory = category;
                        }
                        else
                        {
                          // Product not found
                          isAdded = false;
                        }
                    }
                    else
                    {
                    //Create a new product object
                    var newProduct = new Product
                    {
                        ProdName = name,
                        ProdDescription = description,
                        ProdQuantity = quantity,
                        ProdPrice = price,
                        ProdStatus = status,
                        ProdImg = image,
                        ProdCategory = category
                        };
                        // Add the new product to the context
                        db.Products.InsertOnSubmit(newProduct);
                    }

                    // Submit changes to the database
                    db.SubmitChanges();
                // Success
                isAdded =  true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Failure
                isAdded =  false; 
            }

            return isAdded;
        }

        public SysUser Login(string email, string hashedPassword)
        {
            // case sensetive email comparison
            SysUser user = db.SysUsers.FirstOrDefault(u => (u.Email.ToLower().Equals(email.ToLower()) || u.Username.ToLower().Equals(email)) && u.Password.Equals(hashedPassword));

            // Check if the user exists and return a filtered user object
            if (user != null)
            {
                // exclude password
                user.Password = null;
                return user;
            }

            // Return null if no user found
            return null;
        }

        public bool RegisterUser(string name, string email, string hashedPass, string userType)
        {
            // Placeholder for return value
            bool isReg = false;

            try
            {
                // Check if user with the same email and password already exists
                var existingUser = db.SysUsers.FirstOrDefault(u => u.Username.ToLower().Equals(email.ToLower()));

                if (existingUser != null)
                {
                    // User already exists, return false.
                    return isReg;
                }


                    // Create a new user object
                    var newUser = new SysUser
                    {
                        Name = name,
                        Email = email,
                        Password = hashedPass,
                        Username = email,
                        UserType = userType,
                        RegistrationDate = DateTime.Now
                    };

                    // Add the new user to the database context
                    db.SysUsers.InsertOnSubmit(newUser);

                    // Save changes to the database
                    db.SubmitChanges();

                    // Set isReg to true indicating successful registration
                    isReg = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while registering user: {ex.Message}");
            }

            return isReg;
        }

        //Function to return a list of products based off of their status.
        public List<Product> getProductsByStatus(string ProdStatus)
        {
            //return the whole list of products.
            return db.Products
         .Where(p => p.ProdStatus.ToLower() == ProdStatus.ToLower())
         .ToList();
        }

        //Function to return product using its ID.
        public Product GetProduct(int productId)
        {
            //return just one product
            return db.Products.Where(p => p.ProdId == productId).FirstOrDefault();
        }
    }
}
