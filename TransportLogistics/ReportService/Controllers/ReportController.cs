using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransportLogistics.Domain.Interfaces.Reports.Services;

namespace ReportService.Controllers;

[Route("api/reports/")]
public class ReportController : Controller
{
    private readonly IReportFormService _reportService;
    
    public ReportController(IReportFormService reportService)
    {
        _reportService = reportService;
    }
    
    [HttpGet("ordersAmount")]
    public async Task<IActionResult> GetOrdersAmount()
    {
        var result = await _reportService.GetOrdersAmount();
        return Ok(result);
    }
    
    [HttpGet("priceAmount")]
    public async Task<IActionResult> GetPriceAmount()
    {
        var result = await _reportService.GetPriceAmount();
        return Ok(result);
    }
    
    [HttpGet("priceAmountByCompany")]
    public async Task<IActionResult> GetPriceAmountByCompany()
    {
        var companyPrice = await _reportService.GetPriceAmountByCompany();
        var result = JsonConvert.SerializeObject(companyPrice);
        return Ok(result);
    }
}