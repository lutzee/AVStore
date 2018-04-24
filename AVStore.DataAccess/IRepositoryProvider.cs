using AVStore.DataAccess.Repositories.Abstract;

namespace AVStore.DataAccess
{
    public interface IRepositoryProvider
    {
        IAccountRepository AccountRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
    }
}