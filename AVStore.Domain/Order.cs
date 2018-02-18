using System.Collections.Generic;
using AVStore.DataAccess;

namespace AVStore.Domain
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }

        public decimal OrderCost { get; set; }
    }
}
