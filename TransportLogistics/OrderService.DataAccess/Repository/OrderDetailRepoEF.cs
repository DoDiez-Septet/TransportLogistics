using TransportLogistics.Domain.Models.Order;

namespace OrderService.DataAccess.Repository
{
    public class OrderDetailRepoEF : RepoEF<OrderDetail>, IOrderDetailRepoEF
    {
        public OrderDetailRepoEF(AppFactory appFactory) : base(appFactory)
        { }

        public override Task<bool> Update(OrderDetail orderLine)
        {
            int old = _appFactory.ordersLine.Count(x => x.Id == orderLine.Id);
            if (old != 0)
            {
                _appFactory.ordersLine.Update(orderLine);
                _appFactory.SaveChanges();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
