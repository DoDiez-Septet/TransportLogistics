using TransportLogistics.Domain.Enums.Users;

namespace TransportLogisticUIWebApp.Client.Models.Administrations.Users;

public class UserViewModelToAdd
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.InternalUser;
}