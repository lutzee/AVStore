using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AVStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AVStore.DataAccess.Queries
{
    public class GetProducts
    {
        public class Query : IRequest<IList<Product>>
        {
            public bool ExcludeOutOfStock { get; set; }
        }

        public class Handler : IRequestHandler<Query, IList<Product>>
        {
            private readonly StoreContext context;

            public Handler(StoreContext context)
            {
                this.context = context;
            }

            public async Task<IList<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                IQueryable<Product> products = context.Products;

                if (request.ExcludeOutOfStock)
                {
                    products = context.Products.Where(p => p.InStock);
                }

                return await products.ToListAsync(cancellationToken);
            }
        }
    }
}
