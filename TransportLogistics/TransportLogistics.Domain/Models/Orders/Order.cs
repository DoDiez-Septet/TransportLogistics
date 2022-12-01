using TransportLogistics.Domain.Enums.Orders;

namespace TransportLogistics.Domain.Models.Orders;

public class Order
{
    public int OrderId { get; set; }

    public string OrderDescription { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }
}