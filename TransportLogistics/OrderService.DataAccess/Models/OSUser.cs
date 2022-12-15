namespace OrderService.DataAccess.Models
{
    public class OSUser : TableBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
