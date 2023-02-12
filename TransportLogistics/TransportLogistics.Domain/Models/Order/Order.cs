using TransportLogistics.Domain.Enums.Orders;
using TransportLogistics.Domain.Models.Customers;
using TransportLogistics.Domain.Models.Points;
using TransportLogistics.Domain.Models.Users;

namespace TransportLogistics.Domain.Models.Order
{
    /// <summary>
    /// Класс Заказа на перевозку
    /// </summary>
    public class Orders : BaseTab
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

        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
         
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid OrderLineId { get; set; }
        public OrderDetail? OrderLine { get; set; }
    }
}