using TransportLogisticUIWebApp.Client.Models.Administrations.Customers;

namespace TransportLogisticUIWebApp.Client.Services.Administrations.Customers;

public class CustomerServices
{
    private List<CustomerType>? customerTypes { get; set; }

    private List<CustomerViewModel>? customers { get; set; }

    public CustomerServices()
    {
        CreateCustomerTypes();

        CreateCustomers();
    }

    private void CreateCustomerTypes()
    {
        customerTypes = new List<CustomerType>
        {
            new CustomerType
            {
                CustomerTypeId = 1,
                CustomerTypeName = "VIP Клиент"
            },
            new CustomerType
            {
                CustomerTypeId = 2,
                CustomerTypeName = "Супер клиент"
            },
            new CustomerType
            {
                CustomerTypeId = 3,
                CustomerTypeName = "Обычный"
            },
            new CustomerType
            {
                CustomerTypeId = 4,
                CustomerTypeName = "Неплательщик"
            }
        };
    }

    private void CreateCustomers()
    {
        customers = new List<CustomerViewModel>
        {
            new CustomerViewModel
            {
                CustomerId = Guid.NewGuid().ToString(),//"102019-090-0993890-093",
                Name = "ООО \"Рога и копыта\"",
                PhoneNumber = "+74950982345",
                Email = "grigory.petrov@yandex.ru",
                ContactPerson = "Григорий Петров",
                Address = "Москва, ул. Набережная, д.1"
                //CompanyName = "ООО \"Рога и копыта\"",
                //CompanyNameInformally = "Рожки да ножки)",
                //Inn = "0948478737",
                //KindOfActivity = "Селькохозяйственная деятельность",
                //ContractNumber = "1234 от 05.03.2023",
                //IsCanOperate = true,
                //Kpp = "093948",
                //Ogrn = "0935457475495345345",
                //PaymentAccount = "4089834934787897987493",
                //CustomerType = (customerTypes != null ? customerTypes[0] : null)
            }
        };
    }

    public List<CustomerType>? GetCustomerTypesList()
    {
        return customerTypes;
    }

    public List<CustomerViewModel>? GetCustomers()
    {
        return customers;
    }
}