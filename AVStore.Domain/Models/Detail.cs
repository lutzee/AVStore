using System.Collections.Generic;

namespace AVStore.Domain.Models
{
    public class Detail
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }

        public int TypeId { get; set; }

        public DetailType Type { get; set; }
    }
}
