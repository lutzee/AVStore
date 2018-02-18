using AVStore.Domain;

namespace AVStore.DataAccess.Repositories
{
    public class AccountRepository : AbstractRepository<Account>
    {
        public AccountRepository(StoreContext context) 
            : base(context)
        {
        }
    }
}
