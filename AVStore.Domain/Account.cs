using System.Collections.Generic;
using AVStore.DataAccess;

namespace AVStore.Domain
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public decimal Overdraft { get; set; }

        public ICollection<CustomerAccount> Owners { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}