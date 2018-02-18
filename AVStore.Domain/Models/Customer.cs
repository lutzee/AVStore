using System.Collections.Generic;

namespace AVStore.Domain.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        public ICollection<CustomerAccount> Accounts { get; set; }
    }
}