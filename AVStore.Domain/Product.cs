using System.Collections.Generic;

namespace AVStore.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
