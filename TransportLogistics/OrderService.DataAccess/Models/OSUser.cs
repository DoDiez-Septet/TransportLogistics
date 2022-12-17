namespace OrderService.DataAccess.Models
{
    public class OSUser : TableBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
