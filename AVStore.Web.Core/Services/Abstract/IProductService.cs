using System.Collections.Generic;
using AVStore.Domain.Entities;

namespace AVStore.Web.Core.Services.Abstract
{
    public interface IProductService
    {
        IList<Product> GetProducts(bool excludeOutOfStock);

        Product GetProduct(int productId);
        IList<Detail> GetProductDetails(int productId);
    }
}