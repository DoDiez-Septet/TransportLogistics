using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Domain.Interfaces.Customers.Services;
using TransportLogistics.Domain.Models.Customers; 

namespace CustomerService.Controllers;

[ApiController]
[Route("/api/Customers")]
public class CustomerController : Controller
{
    private readonly ICustomerServices _CustomerServices;

    public CustomerController(ICustomerServices CustomerServices) 
    { 
        _CustomerServices = CustomerServices;
    }

    [HttpGet]
    public ActionResult<IReadOnlyCollection<Customer>> GetAllCustomers()
    {
        var Customers = _CustomerServices.GetAll().ToArray();

        if (!Customers.Any())
        {
            return NotFound();
        }

        return Ok(Customers);
    }

    [HttpGet("{Id}")]
    public ActionResult<Customer> GetCustomer(string Id)
    {
        return _CustomerServices.GetById(Id) switch
        {
            null => NotFound(),
            var Customer => Customer
        };
    }

    [HttpPost]
    public IActionResult AddCustomer([FromBody]Customer Customer)
    {
        var newCustomerId = _CustomerServices.New(Customer);
        return Ok($"api/Customers/{newCustomerId}");
    }

    //[HttpPut("{Id}")]
    [HttpPut]
    public ActionResult<string> UpdateCustomer([FromBody]Customer Customer)
    {
        var newCustomerId = _CustomerServices.Edit(Customer);
        return Ok($"api/Customers/{newCustomerId.Id}");
    }

    [HttpDelete("{Id}")]
    public ActionResult DeleteCustomer(string Id)
    {
        _CustomerServices.Delete(Id);
        return Ok();
    }
}