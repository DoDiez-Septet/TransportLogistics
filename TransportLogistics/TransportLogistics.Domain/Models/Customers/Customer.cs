namespace TransportLogistics.Domain.Models.Customers;

internal class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFirstName { get; set; } = string.Empty;

    public string CustomerLastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Можно добавить объект Address
}