using System.Collections.Generic;
using AVStore.DataAccess;
using AVStore.Domain.Entities;
using AVStore.Web.Core.Services.Abstract;

namespace AVStore.Web.Core.Services.Concrete
{
    public class ProductService : IProductService, IService<Product>
    {
        private readonly IRepositoryProvider repositoryProvider;

        public ProductService(IRepositoryProvider repositoryProvider)
        {
            this.repositoryProvider = repositoryProvider;
        }

        public IList<Product> GetProducts(bool excludeOutOfStock)
        {
            return repositoryProvider.ProductRepository.GetProducts(excludeOutOfStock);
        }

        public Product GetProduct(int productId)
        {
            return repositoryProvider.ProductRepository.GetProduct(productId);
        }

        public IList<Detail> GetProductDetails(int productId)
        {
            return repositoryProvider.ProductRepository.GetProductDetails(productId);
        }
    }
}
