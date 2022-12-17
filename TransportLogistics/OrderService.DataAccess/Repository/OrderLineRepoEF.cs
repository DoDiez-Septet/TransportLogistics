namespace OrderService.DataAccess.Repository
{
    public class OrderLineRepoEF : RepoEF<OrderLine>, IOrderLineRepoEF
    {
        public OrderLineRepoEF(AppFactory appFactory) : base(appFactory)
        { }

        public override Task<bool> Update(OrderLine orderLine)
        {
            OrderLine old = _appFactory.ordersLine.FirstOrDefault(x => x.Id == orderLine.Id);
            if (old != null)
            {
                old.Description = orderLine.Description;
                _appFactory.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
