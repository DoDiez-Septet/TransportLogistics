using System.Text.Json;
using Microsoft.Extensions.Configuration;
using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Models.Order;

namespace ReportService.BusinessLogic.Services;

public class OrderServicesDataRequester : IOrderServicesDataRequester
{
    private readonly string _ordersApi;

    public OrderServicesDataRequester(IConfiguration configuration)
    {
        _ordersApi = configuration["OrdersAPI"] ?? string.Empty;
    }

    public async Task<IEnumerable<Orders>> GetAll()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(_ordersApi);
        var content = await response.Content.ReadAsStreamAsync();
        var result = JsonSerializer.DeserializeAsyncEnumerable<Orders>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var orderList = new List<Orders>();
        await foreach (var order in result)
        {
            if (order != null) orderList.Add(order);
        }
        
        return orderList;
    }
}