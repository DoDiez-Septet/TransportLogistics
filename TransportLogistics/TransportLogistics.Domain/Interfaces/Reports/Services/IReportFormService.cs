namespace TransportLogistics.Domain.Interfaces.Reports.Services;

public interface IReportFormService
{
    public Task<int> GetOrdersAmount();
    public Task<double> GetPriceAmount();
    public Task<List<(string?, double)>> GetPriceAmountByCompany();
}