namespace TransportLogistics.Domain.Models.Orders;

public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public string UnitDescription { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }
}