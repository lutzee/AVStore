namespace AVStore.Domain.Entities
{
    public class CustomerAccount
    {
        public int AccountId { get; set; }

        public Account Account { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
