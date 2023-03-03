using System.Text.Json.Serialization;

namespace TransportLogisticUIWebApp.Client.Models;

public class UserViewModel : UserViewModelToAdd
{
    [JsonPropertyName("Id")]
    public string UserId { get; set; } = string.Empty;
}