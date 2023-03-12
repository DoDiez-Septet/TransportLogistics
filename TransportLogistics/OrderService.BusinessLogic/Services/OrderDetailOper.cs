using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Order;

namespace OrderService.BusinessLogic.Services
{
    public class OrderDetailOper : IOrderDetailOper
    {
        private readonly IOrderDetailRepoEF _repo;

        public OrderDetailOper(IOrderDetailRepoEF repo)
        {
            _repo = repo;
        }

        public Task<List<OrderDetail>> Get()
        {
            return _repo.Get();
        }

        public Task<OrderDetail> Get(string guid)
        {
            OrderDetail? result = _repo?.AllBase?.FirstOrDefault(x => x.Id == Guid.Parse(guid));
            if (result == null) 
            {
                Exception ex = new Exception($"OrderDetail с Id = {guid} не найден!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }
            return Task.FromResult(result);
        }

        public Task Add(OrderDetail orderDetail) 
        {
            return _repo.Add(orderDetail);
        }

        public Task<bool> Update(OrderDetail orderDetail)
        {
            int? count = _repo.AllBase?.Count(x => x.Id == orderDetail.Id);
            if (count == 0)
            {
                Exception ex = new Exception($"OrderDetail с Id = {orderDetail.Id} не найден!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }
            return _repo.Update(orderDetail);
        }

        public Task<bool> Delete(string guid) 
        {
            int? count = _repo.AllBase?.Count(x => x.Id == Guid.Parse(guid));
            if (count == 0)
            {
                Exception ex = new Exception($"OrderDetail с Id = {guid} не найден!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }
            return _repo.Delete(Guid.Parse(guid));
        }
    }
}
