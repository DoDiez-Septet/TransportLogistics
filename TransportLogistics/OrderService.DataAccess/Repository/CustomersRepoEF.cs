using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Models.Customers;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Repository
{
    internal class CustomersRepoEF : ICustomerRepoEF
    {
        private readonly string customerApi = String.Empty;
        private List<Customer> customer = new List<Customer>();
        public CustomersRepoEF(IConfiguration config)
        {
            customerApi = config["CustomersAPI"] ?? String.Empty;
        }

        public Task<bool> Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> Get()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(customerApi);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<Customer>();
            }

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Status Code = {response.StatusCode}\n Message:\n{result}");
            return JsonConvert.DeserializeObject<List<Customer>>(result);
        }

        public async Task<Customer?> Get(Guid guid)
        {
            customer = await Get();
            return customer.FirstOrDefault(x => x.Id == guid) ?? null;
        }
    }
}
