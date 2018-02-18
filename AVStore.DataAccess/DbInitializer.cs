using System.Linq;
using AVStore.Domain.Models;

namespace AVStore.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.DetailTypes.AddRange(DetailType.List().ToList());
            context.SaveChanges();
        }
    }
}
