using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVStore.Domain.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        [JsonIgnore]
        public ICollection<OrderLine> OrderLines { get; set; }

        public decimal OrderCost { get; set; }
    }
}
