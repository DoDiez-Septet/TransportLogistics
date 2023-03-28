using TransportLogistics.Domain.Interfaces.Common;
using TransportLogistics.Domain.Interfaces.Reports.Services;

namespace ReportService.BusinessLogic.Services;

public class ReportFormService : IReportFormService
{
    private IOrderServicesDataRequester _orderServicesDataRequester;

    public ReportFormService(IOrderServicesDataRequester orderServicesDataRequester)
    {
        _orderServicesDataRequester = orderServicesDataRequester;
    }

    public async Task<int> GetOrdersAmount()
    {
        var orders = await _orderServicesDataRequester.GetAll();
        var amount = orders.Count();
        return amount;
    }

    public async Task<double> GetPriceAmount()
    {
        var orders = await _orderServicesDataRequester.GetAll();
        var priceAmount = orders.Select(o => o.Price).Sum();
        return priceAmount;
    }

    public async Task<List<(string?, double)>> GetPriceAmountByCompany()
    {
        var orders = await _orderServicesDataRequester.GetAll();
        var priceAmountByCompany = orders
            .GroupBy(o => o.Customer)
            .Select(o => (Customer: o.Key?.Name.ToString(), PriceAmount: o.Sum(p => p.Price)))
            .ToList();
        return priceAmountByCompany;
    }
}