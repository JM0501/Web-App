using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PaperD_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaperD" in both code and config file together.
    [ServiceContract]
    public interface IPaperD
    {
        [OperationContract]
        SysUser Login(string Email, string Password);
        [OperationContract]
        bool RegisterUser(string name, string email, string HashedPass, string usertype);
        [OperationContract]
        List<Product> getProductsByStatus(string ProdStatus);
        [OperationContract]
        Product GetProduct(int productId);
        [OperationContract]
        bool addProduct(int prodId, string name, string description, int quantity, decimal price, string status, string image,string category);
        [OperationContract]
        bool addReview(int prodId, int userId, int stars, string review);
        [OperationContract]
        bool EditReview(int revId, int stars, string review);
        [OperationContract]
        ProdReview retrievReview(int userid, int productId);
    }
}
