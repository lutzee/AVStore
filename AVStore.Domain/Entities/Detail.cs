using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVStore.Domain.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        [JsonIgnore]
        public ICollection<ProductDetail> ProductDetails { get; set; }

        public int TypeId { get; set; }

        public DetailType Type { get; set; }
    }
}
