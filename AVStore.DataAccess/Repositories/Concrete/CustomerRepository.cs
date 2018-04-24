using AVStore.DataAccess.Repositories.Abstract;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess.Repositories.Concrete
{
    public class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StoreContext context) 
            : base(context)
        {
        }
    }
}
