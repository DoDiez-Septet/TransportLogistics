namespace TransportLogisticUIWebApp.Client.Models.Administrations.Customers;

public class CustomerDetailsViewModel
{
    public string CompanyName { get; set; } = string.Empty;

    public string CompanyNameInformally { get; set; } = string.Empty;

    public string ContractNumber { get; set; } = string.Empty;

    public string KindOfActivity { get; set; } = string.Empty;

    public string PaymentAccount { get; set; } = string.Empty;

    public string Kpp { get; set; } = string.Empty;

    public string Ogrn { get; set; } = string.Empty;

    public string Inn { get; set; } = string.Empty;

    public bool IsCanOperate { get; set; } = false;

    public CustomerType? CustomerType { get; set; }
}
