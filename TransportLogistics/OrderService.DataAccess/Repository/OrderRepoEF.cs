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
                .Include(x => x.OSUser)
                .Include(x => x.OSCustomer)
                .Include(x => x.OrderLine)
                .ToListAsync();
        }
    }
}
