using AVStore.DataAccess.Repositories.Abstract;

namespace AVStore.DataAccess
{
    public class RepositoryProvider : IRepositoryProvider
    {
        // Normally I'd use an IoC container that can auto-wire properties for these kind of things, I.E. Autofac
        // For this case though to keep it simple I'm using constructor injection
        public RepositoryProvider(
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IAccountRepository accountRepository)
        {
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
            AccountRepository = accountRepository;
        }

        public IProductRepository ProductRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public ICustomerRepository CustomerRepository { get; set; }

        public IAccountRepository AccountRepository { get; set; }
    }
}
