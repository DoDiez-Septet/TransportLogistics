using AutoMapper;
using TransportLogistics.Domain.Models.Order;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Repository
{
    public class OrderRepoEF : RepoEF<OrdersDb>, IOrderRepoEF
    {
        private readonly IUserRepoEF _user;
        private readonly IMapper _mapper;
        public OrderRepoEF(AppFactory appContext, IUserRepoEF userRepoEF, IMapper mapper) : base(appContext)
        { 
            _user = userRepoEF;
            _mapper = mapper;
        }

        public async Task<List<Orders>> Get()
        {
            var orderDbList = await _appFactory.orders
                .Include(x => x.PointOfDeparture)
                .Include(x => x.PointOfDestination)
                .ToListAsync();

            if (orderDbList.Count == 0)
            {
                return new List<Orders>();
            }


            List<Orders> orderList = new List<Orders>();
            foreach(var order in orderDbList)
            {
                orderList.Add(_mapper.Map<Orders>(order));
            }

            Dictionary<Guid, User> usersId = new Dictionary<Guid, User>();

            var Ids = orderList.Select(x => x.UserId).Distinct().ToList();

            foreach (var id in Ids)
            {
                if (id != Guid.Empty)
                {
                    var thisUser = await _user.Get(id);
                    if (thisUser != null) 
                    {
                        usersId.Add(id, thisUser);
                    }
                }
            }

            foreach (var order in orderList)
            {
                if (order.UserId != Guid.Empty) 
                {
                    order.User = usersId[order.UserId];
                }
            }

            return orderList;
        }

        public async Task<Orders> Get(Guid guid)
        {
            var orderDb = await _appFactory.orders
                .Include(x => x.PointOfDeparture)
                .Include(x => x.PointOfDestination)
                .Include(x => x.OrderLine)
                .FirstOrDefaultAsync(x => x.Id == guid);

            Orders order = new();
            if (orderDb != null)
            {
                order = _mapper.Map<Orders>(orderDb);
                if (order.UserId != Guid.Empty)
                {
                    var id = await _user.Get(order.UserId);
                    if (id != null)
                    {
                        order.User = id;
                    }
                }
            }
            return order;
        }

        public async Task<Guid> Add(Orders entity)
        {
            OrdersDb orders = _mapper.Map<OrdersDb>(entity);
            return await base.Add(orders);
        }

        public async Task<bool> Update(Orders entity)
        {
            return await base.Update(_mapper.Map<OrdersDb>(entity));
        }

    }
}
