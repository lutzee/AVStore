using AVStore.Domain;

namespace AVStore.DataAccess.Repositories
{
    public class CustomerRepository : AbstractRepository<Customer>
    {
        public CustomerRepository(StoreContext context) 
            : base(context)
        {
        }
    }
}
