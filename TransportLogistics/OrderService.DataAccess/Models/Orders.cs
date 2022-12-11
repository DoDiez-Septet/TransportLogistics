using TransportLogistics.Domain.Enums.Orders;
namespace OrderService.DataAccess.Models
{
    public class Orders
    {
        public long Id { get; set; }
        public string OrderDescription { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }

    }
}
