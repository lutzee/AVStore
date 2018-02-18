using System.Collections.Generic;
using System.Linq;
using AVStore.Domain.Models;

namespace AVStore.DataAccess.Repositories
{
    public class ProductRepository : AbstractRepository<Product>
    {
        public ProductRepository(StoreContext context) 
            : base(context)
        {
        }

        /// <summary>
        /// Get all product details for Product
        /// </summary>
        /// <param name="productId">Id for the product</param>
        /// <returns>A list of Product details</returns>
        public IEnumerable<ProductDetail> GetProductDetails(int productId)
        {
            return Context.ProductDetails
                .Where(x => x.ProductId == productId)
                .ToList();
        }

        /// <summary>
        /// Get all orders containing a product
        /// </summary>
        /// <param name="productId">Product Id to find</param>
        /// <returns>A list of orders that contain the product requested</returns>
        public IEnumerable<Order> GetOrdersContainingProduct(int productId)
        {
            return Context.OrderLines
                .Where(x => x.ProductId == productId)
                .Select(line => line.Order)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Get all customers who have ordered the specified product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomersThatPurchasedProduct(int productId)
        {
            return Context.OrderLines
                .Where(x => x.ProductId == productId)
                .Select(line => line.Order)
                .Select(order => order.Account)
                .Select(account => account.Owners)
                .SelectMany(customerAccounts => customerAccounts.Select(customer => customer.Customer))
                .ToList();
        }
    }
}
