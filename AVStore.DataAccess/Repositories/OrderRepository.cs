using AVStore.Domain;

namespace AVStore.DataAccess.Repositories
{
    public class OrderRepository : AbstractRepository<Order>
    {
        public OrderRepository(StoreContext context) 
            : base(context)
        {
        }
    }
}
