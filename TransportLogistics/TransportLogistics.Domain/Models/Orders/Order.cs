using TransportLogistics.Domain.Enums.Orders;

namespace TransportLogistics.Domain.Models.Orders;

public class Order
{
    public Guid Id { get; set; }

    public string Number { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;

    public string Description { get; set; } = string.Empty;

    public OrderStatus Status { get; set; }

    public string From { get; set; } = string.Empty;

    public string To { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public Guid CustomerId { get; set; }
}