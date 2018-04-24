using System.Collections.Generic;
using Newtonsoft.Json;

namespace AVStore.Domain.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => $"{FirstName} {LastName}";

        [JsonIgnore]
        public ICollection<CustomerAccount> Accounts { get; set; }
    }
}