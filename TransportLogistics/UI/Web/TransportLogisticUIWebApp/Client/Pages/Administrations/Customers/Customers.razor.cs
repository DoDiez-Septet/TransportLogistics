using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using MudBlazor;
using System.Net.Http;
using TransportLogistics.Domain.Models.Customers;
using TransportLogisticUIWebApp.Client.Models.Administrations.Customers;
using TransportLogisticUIWebApp.Client.Pages.Administrations.Customers.Dialogs;
using TransportLogisticUIWebApp.Client.Services.Administrations.Customers;

namespace TransportLogisticUIWebApp.Client.Pages.Administrations.Customers;

public partial class Customers : ComponentBase
{
    [Inject]
    IHttpClientFactory httpClientFactory { get; set; }

    [Inject]
    IDialogService dialogService { get; set; }

    [Inject]
    ISnackbar snackBar { get; set; }

    private List<CustomerViewModel>? customers;

    private List<CustomerType>? customerTypes;

    private CustomerServices? customerServices;

    private CustomerViewModel? selectedCustomer;

    private bool dense = true;
    private bool hover = true;
    private bool striped = true;
    private bool bordered = true;
    private string searchString1 = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        customerServices = new CustomerServices();
        customers = customerServices.GetCustomers();
        customerTypes = customerServices.GetCustomerTypesList();
    }

    private async void AddCustomerAsync()
    {
        var parameters = new DialogParameters
        {
            ["customer"] = new CustomerViewModelToAdd(),
            ["customerTypes"] = customerTypes,
            ["header"] = "Добавление нового заказчика",
            ["addButtonText"] = "Добавить"
        };

        var dialog = await dialogService.ShowAsync<AddEditCustomer>("Добавление клиента", parameters);
        var result = await dialog.Result;

        var addedCustomer = result.Data as CustomerViewModel;// ToAdd;

        if (!result.Canceled)
        {
            //var responce = await httpClient.PostAsJsonAsync<CustomerViewModelToAdd>("api/customer/", addedUser);

            var customersCountBefore = customers.Count;

            customers.Add(addedCustomer);

            var customersCountAfter = customers.Count;

            if (customersCountAfter > customersCountBefore)//responce == 200)
            {
                snackBar.Add("Клиент добавлен", Severity.Success);
                //await FetchUserList();
            }
            else
            {
                //snackBar.Add($"Ошибка при добавления пользователя\r\n{responce.StatusCode}", Severity.Error);
                snackBar.Add($"Ошибка при добавления клиента\r\nResponce Code", Severity.Error);
            }
        }
    }

    private async void UpdateCustomerAsync(CustomerViewModel сustomer)
    {
        if (сustomer is not null)
        {
            var parameters = new DialogParameters
            {
                ["customer"] = selectedCustomer,
                ["customerTypes"] = customerTypes,
                ["header"] = "Обновления нового заказчика",
                ["addButtonText"] = "Обновить"
            };

            var dialog = await dialogService.ShowAsync<AddEditCustomer>("Обновление клиента", parameters);
            var result = await dialog.Result;

            var updatedCustomer = result.Data as CustomerViewModel;

            if (!result.Canceled)
            {
                //var responce = await httpClient.PutAsJsonAsync<CustomerViewModel>("api/customers/", updatedUser);

                var customer = customers.FirstOrDefault(x => x.CustomerId == updatedCustomer.CustomerId);

                if (customer is not null)
                {
                    customers.Remove(customer);
                    customers.Add(updatedCustomer);

                    snackBar.Add("Клиент обнавлён", Severity.Success);
                    //await FetchUserListAsync();
                }
                else
                {
                    snackBar.Add($"Ошибка при обновление клиента\r\nКод ошибки", Severity.Error);
                    //snackBar.Add($"Ошибка при обновление пользователя\r\n{responce.StatusCode}", Severity.Error);
                }
            }
        }
        else
        {
            snackBar.Add($"Выбирите клиента", Severity.Warning);
        }
    }

    private bool FilterFunc1(CustomerViewModel customer) => FilterFunc(customer, searchString1);

    private bool FilterFunc(CustomerViewModel customer, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (customer.Name.Contains(searchString))
            return true;
        if (customer.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.PhoneNumber.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (customer.ContactPerson.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{customer.Name} {customer.ContactPerson}".Contains(searchString))
            return true;
        //if ($"{customer.FirstName} {user.LastName} {user.Email}".Contains(searchString))
        //    return true;

        return false;
    }
}