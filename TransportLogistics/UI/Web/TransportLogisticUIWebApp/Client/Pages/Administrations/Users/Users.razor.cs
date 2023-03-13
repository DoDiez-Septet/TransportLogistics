using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http.Json;
using TransportLogisticUIWebApp.Client.Models.Administrations.Users;
using TransportLogisticUIWebApp.Client.Pages.Administrations.Users.Dialogs;

namespace TransportLogisticUIWebApp.Client.Pages.Administrations.Users;

public partial class Users : ComponentBase
{
    [Inject]
    IHttpClientFactory httpClientFactory { get; set; }

    [Inject]
    IDialogService dialogService { get; set; }

    [Inject]
    ISnackbar snackBar { get; set; }

    private bool dense = true;
    private bool hover = true;
    private bool striped = true;
    private bool bordered = true;
    private string searchString1 = string.Empty;

    private string userInfo = string.Empty;

    private UserViewModel selectedItem1 = null;
    private HashSet<UserViewModel> selectedItems = new HashSet<UserViewModel>();

    private List<UserViewModel>? users = new List<UserViewModel>();
    private UserViewModel newUser = new UserViewModel();

    private HttpClient httpClient = null;

    protected override async Task OnInitializedAsync()
    {
        httpClient = httpClientFactory.CreateClient("GatewayApi");
        httpClient.Timeout = TimeSpan.FromSeconds(600);

        await base.OnInitializedAsync();
        await FetchUserListAsync();
    }

    private async Task FetchUserListAsync()
    {
        users = await httpClient.GetFromJsonAsync<List<UserViewModel>>("api/users");
    }

    private async Task AddUserAsync()
    {
        var parameters = new DialogParameters
        {
            ["user"] = new UserViewModelToAdd(),
            ["header"] = "Добавление нового пользователя",
            ["addButtonText"] = "Добавить"
        };

        var dialog = await dialogService.ShowAsync<AddEditUser>("Добавление пользователя", parameters);
        var result = await dialog.Result;

        var addedUser = result.Data as UserViewModelToAdd;

        if (!result.Canceled)
        {
            var responce = await httpClient.PostAsJsonAsync<UserViewModelToAdd>("api/users/", addedUser);
            if (responce.IsSuccessStatusCode)
            {
                snackBar.Add("Пользователь добавлен", Severity.Success);
                await FetchUserListAsync();
            }
            else
            {
                snackBar.Add($"Ошибка при добавления пользователя\r\n{responce.StatusCode}", Severity.Error);
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

            var dialog = await dialogService.ShowAsync<AddEditUser>("Обновление пользователя", parameters);
            var result = await dialog.Result;

            var updatedUser = result.Data as UserViewModel;

            if (!result.Canceled)
            {
                var responce = await httpClient.PutAsJsonAsync<UserViewModel>("api/users/", updatedUser);
                if (responce.IsSuccessStatusCode)
                {
                    snackBar.Add("Пользователь обнавлён", Severity.Success);
                    await FetchUserListAsync();
                }
                else
                {
                    snackBar.Add($"Ошибка при обновление пользователя\r\n{responce.StatusCode}", Severity.Error);
                }
            }
        }
        else
        {
            snackBar.Add($"Выбирите пользователя", Severity.Warning);
        }
    }

    private async Task DeleteUser(int userId)
    {
        var result = await httpClient.DeleteAsync($"api/users/{userId}");
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
}