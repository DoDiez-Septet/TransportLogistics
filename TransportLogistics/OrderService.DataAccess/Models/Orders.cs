using TransportLogistics.Domain.Enums.Orders;
namespace OrderService.DataAccess.Models
{
    public class Orders : TableBase
    {
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public OrderStatus? Status { get; set; }

        public Guid PointOfDepartureId { get; set; }
        public Point PointOfDeparture { get; set; }
        
        public Guid PointOfDestinationId { get; set; }
        public Point PointOfDestination { get; set; }

        public double Price { get; set; }

        public Guid OSCustomerId { get; set; }
        public OSCustomer? OSCustomer { get; set; }

        public Guid OSUserId { get; set; }
        public OSUser? OSUser { get; set; }

        public Guid OrderLineId { get; set; }
        public OrderLine? OrderLine { get; set; }

    }
}
