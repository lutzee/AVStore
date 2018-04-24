using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVStore.Domain.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public decimal Overdraft { get; set; }

        [JsonIgnore]
        public ICollection<CustomerAccount> Owners { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}