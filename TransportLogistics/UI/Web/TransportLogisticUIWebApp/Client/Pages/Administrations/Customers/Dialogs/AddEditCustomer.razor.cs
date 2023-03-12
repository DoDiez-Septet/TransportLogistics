using Microsoft.AspNetCore.Components;
using MudBlazor;
using TransportLogisticUIWebApp.Client.Models.Administrations.Customers;

namespace TransportLogisticUIWebApp.Client.Pages.Administrations.Customers.Dialogs;

public partial class AddEditCustomer : ComponentBase
{
    [CascadingParameter]
    MudDialogInstance? MudDialog { get; set; }

    [Parameter]
    public CustomerViewModelToAdd customer { get; set; } = new CustomerViewModel();

    [Parameter]
    public List<CustomerType> customerTypes { get; set; }

    [Parameter]
    public string header { get; set; } = string.Empty;
    
    [Parameter]
    public string addButtonText { get; set; } = string.Empty;

    private CustomerType selectedCustomerTypes { get; set; }

    bool isShow;
    InputType PasswordInput = InputType.Password;
    string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

    private void Cancel()
    {
        MudDialog?.Cancel();
    }

    private void CustomerAddUpdate()
    {
        MudDialog?.Close(DialogResult.Ok(customer));
    }

    void ShowHidePassword()
    {
        if (isShow)
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