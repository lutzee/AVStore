using System.Collections.Generic;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess.Repositories.Abstract
{
    public interface IProductRepository
    {
        IList<Customer> GetAllCustomersThatPurchasedProduct(int productId);
        IList<Order> GetOrdersContainingProduct(int productId);
        IList<Detail> GetProductDetails(int productId);
        IList<Product> GetProducts(bool excludeOutOfStock = false);
        Product GetProduct(int productId);
    }
}