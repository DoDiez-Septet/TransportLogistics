using Microsoft.AspNetCore.Components;
using MudBlazor;
using TransportLogisticUIWebApp.Client.Models;

namespace TransportLogisticUIWebApp.Client.Pages.Users.Dialogs;

public partial class AddEditUser : ComponentBase
{
    [CascadingParameter] 
    MudDialogInstance? MudDialog { get; set; }

    [Parameter] 
    public UserViewModelToAdd user { get; set; } = new UserViewModel();

    [Parameter] 
    public string header { get; set; } = string.Empty;
    [Parameter] 
    public string addButtonText { get; set; } = string.Empty;

    bool isShow;
    InputType PasswordInput = InputType.Password;
    string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

    private void Cancel()
    {
        MudDialog?.Cancel();
    }

    private void UserAddUpdate()
    {
        MudDialog?.Close(DialogResult.Ok(user));
    }

    void ShowHidePassword()
    {
        if(isShow)
        {
            isShow = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }
        else
        {
            isShow = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
}