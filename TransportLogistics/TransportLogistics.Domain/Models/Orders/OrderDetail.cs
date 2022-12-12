namespace TransportLogistics.Domain.Models.Orders;

public class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public string UnitDescription { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    /// <summary>
    /// В см - поэтому используем целое число
    /// </summary>
    public int Widtht { get; set; }

    /// <summary>
    /// В см - поэтому используем целое число
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// В см - поэтому используем целое число
    /// </summary>
    public int Length { get; set; }

    public int Weight { get; set; }
}