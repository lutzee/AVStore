using AVStore.DataAccess.Repositories.Abstract;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess.Repositories.Concrete
{
    public class AccountRepository : AbstractRepository<Account>, IAccountRepository
    {
        public AccountRepository(StoreContext context) 
            : base(context)
        {
        }
    }
}
