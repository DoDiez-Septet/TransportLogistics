using System.Text.Json.Serialization;

namespace TransportLogisticUIWebApp.Client.Models.Administrations.Customers;

public class CustomerViewModel : CustomerViewModelToAdd
{
    [JsonPropertyName("Id")]
    public string CustomerId { get; set; } = string.Empty;
}