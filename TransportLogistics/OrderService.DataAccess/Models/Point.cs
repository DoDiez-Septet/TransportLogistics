namespace OrderService.DataAccess.Models
{
    public class Point : TableBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
