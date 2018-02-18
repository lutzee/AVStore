using System.Collections.Generic;
using AVStore.DataAccess;

namespace AVStore.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
