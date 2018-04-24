using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVStore.Domain.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public decimal Price { get; set; }

        [JsonIgnore]
        public ICollection<ProductDetail> ProductDetails { get; set; }

        [JsonIgnore]
        public ICollection<OrderLine> OrderLines { get; set; }

        public bool InStock { get; set; }
    }
}
