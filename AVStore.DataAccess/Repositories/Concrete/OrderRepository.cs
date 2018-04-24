using AVStore.DataAccess.Repositories.Abstract;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess.Repositories.Concrete
{
    public class OrderRepository : AbstractRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreContext context) 
            : base(context)
        {            
        }
    }
}
