using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using TransportLogistics.Domain.Models.Order;
using TransportLogisticUIWebApp.Client.Models.Administrations.Users;
using TransportLogisticUIWebApp.Client.Pages.Administrations.Users.Dialogs;
using static MudBlazor.CategoryTypes;

namespace TransportLogisticUIWebApp.Client.Pages.Operations.OrdersOps;

public partial class OrdersList : Microsoft.AspNetCore.Components.ComponentBase
{
    [Inject]
    IHttpClientFactory httpClientFactory { get; set; }

    [Inject]
    IConfiguration config { get; set; }

    [Inject]
    IDialogService dialogService { get; set; }

    [Inject]
    ISnackbar snackBar { get; set; }

    HttpClient httpClient = null;

    private List<Orders>? orders;

    private Orders? selectedCustomer;

    private bool dense = true;
    private bool hover = true;
    private bool striped = true;
    private bool bordered = true;
    private string searchString1 = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        httpClient = httpClientFactory.CreateClient("GatewayApi");
        httpClient.Timeout = TimeSpan.FromSeconds(600);

        await base.OnInitializedAsync();
        await FetchUserListAsync();
    }

    private async Task FetchUserListAsync()
    {
        orders = await httpClient.GetFromJsonAsync<List<Orders>>("api/orders");
    }

    private async Task AddUserAsync()
    {
        var parameters = new DialogParameters
        {
            ["user"] = new UserViewModelToAdd(),
            ["header"] = "Добавление нового пользователя",
            ["addButtonText"] = "Добавить"
        };

        var dialog = await dialogService.ShowAsync<AddEditUser>("Добавление заказа", parameters);
        var result = await dialog.Result;

        var addedOrder = result.Data as Orders;

        if (!result.Canceled)
        {
            var responce = await httpClient.PostAsJsonAsync<Orders>("api/orders/", addedOrder);
            if (responce.IsSuccessStatusCode)
            {
                snackBar.Add("Заказ добавлен", Severity.Success);
                await FetchUserListAsync();
            }
            else
            {
                snackBar.Add($"Ошибка при добавления заказа\r\n{responce.StatusCode}", Severity.Error);
            }
        }
    }

    private async Task UpdateUserAsync(UserViewModel user)
    {
        if (user is not null)
        {
            var parameters = new DialogParameters
            {
                ["user"] = user,
                ["header"] = "Обновление информации о пользователе",
                ["addButtonText"] = "Обновить"
            };

            var dialog = await dialogService.ShowAsync<AddEditUser>("Обновление заказа", parameters);
            var result = await dialog.Result;

            var updatedUser = result.Data as UserViewModel;

            if (!result.Canceled)
            {
                var responce = await httpClient.PutAsJsonAsync<UserViewModel>("api/orders/", updatedUser);
                if (responce.IsSuccessStatusCode)
                {
                    snackBar.Add("Заказ обнавлён", Severity.Success);
                    await FetchUserListAsync();
                }
                else
                {
                    snackBar.Add($"Ошибка при обновление заказа\r\n{responce.StatusCode}", Severity.Error);
                }
            }
        }
        else
        {
            snackBar.Add($"Выбирите пользователя", Severity.Warning);
        }
    }

    private async Task DeleteOrder(int orderId)
    {
        var result = await httpClient.DeleteAsync($"api/orders/{orderId}");
        await FetchUserListAsync();
    }

    private bool FilterFunc1(UserViewModel user) => FilterFunc(user, searchString1);

    private bool FilterFunc(UserViewModel user, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        if (user.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (user.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (user.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ($"{user.FirstName} {user.LastName}".Contains(searchString))
            return true;
        if ($"{user.FirstName} {user.LastName} {user.Email}".Contains(searchString))
            return true;

        return false;
    }

    // style the rows where the Element.Position == 0 to have italic text.
    private Func<Orders, int, string> _rowStyleFunc => (x, i) =>
    {
        if (x.Customer!.Email.Contains("@"))
            return "font-style:italic";

        return "";
    };
    // style the cells according to the element's physical classification and the molar mass.
    private Func<Orders, string> _cellStyleFunc => x =>
    {
        string style = "";

        //if (x.Number == 1)
        //    style += "background-color:#8CED8C";

        //else if (x.Number == 2)
        //    style += "background-color:#E5BDE5";

        //else if (x.Number == 3)
        //    style += "background-color:#EACE5D";

        //else if (x.Number == 4)
        //    style += "background-color:#F1F165";

        //if (x.Molar > 5)
        //    style += ";font-weight:bold";

        return style;
    };
}