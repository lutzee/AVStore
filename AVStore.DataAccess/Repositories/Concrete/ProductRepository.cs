using System.Collections.Generic;
using System.Linq;
using AVStore.DataAccess.Repositories.Abstract;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess.Repositories.Concrete
{
    public class ProductRepository : AbstractRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext context) 
            : base(context)
        {
        }

        public IList<Product> GetProducts(bool excludeOutOfStock = false)
        {
            IQueryable<Product> products = Context.Products;

            if (excludeOutOfStock)
            {
                products = products.Where(p => p.InStock);
            }

            return products.ToList();
        }

        public Product GetProduct(int productId)
        {
            return Context.Products.FirstOrDefault(p => p.Id == productId);
        }

        /// <summary>
        /// Get all product details for Product
        /// </summary>
        /// <param name="productId">Id for the product</param>
        /// <returns>A list of Product details</returns>
        public IList<Detail> GetProductDetails(int productId)
        {
            return Context.ProductDetails
                .Where(p => p.ProductId == productId)
                .Select(pd => pd.Detail)
                .ToList();
        }

        /// <summary>
        /// Get all orders containing a product
        /// </summary>
        /// <param name="productId">Product Id to find</param>
        /// <returns>A list of orders that contain the product requested</returns>
        public IList<Order> GetOrdersContainingProduct(int productId)
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
        public IList<Customer> GetAllCustomersThatPurchasedProduct(int productId)
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
