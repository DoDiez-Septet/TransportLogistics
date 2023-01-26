using TransportLogistics.Domain.Interfaces;

namespace OrderService.DataAccess.Models
{
    public class Point : TableBase, IPoint
    {
        public string Name { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
