using TransportLogistics.Domain.Models.Order;

namespace OrderService.DataAccess.Repository
{
    public class OrderRepoEF : RepoEF<Orders>, IOrderRepoEF
    {
        public OrderRepoEF(AppFactory appContext) : base(appContext)
        { }

        public override async Task<List<Orders>> Get()
        {
            return await _appFactory.orders
                .Include(x => x.PointOfDeparture)
                .Include(x => x.PointOfDestination)
                .Include(x => x.User)
                .Include(x => x.Customer)
                .Include(x => x.OrderLine)
                .ToListAsync();
        }
    }
}
