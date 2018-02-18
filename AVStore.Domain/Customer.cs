using System.Collections.Generic;
using AVStore.DataAccess;

namespace AVStore.Domain
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