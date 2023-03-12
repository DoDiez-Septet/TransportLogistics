using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLogistics.Domain.Enums.Orders;
using TransportLogistics.Domain.Models;
using TransportLogistics.Domain.Models.Order;
using TransportLogistics.Domain.Models.Points;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Models
{
    public class OrdersDb : BaseTab
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

        public Guid? CustomerId { get; set; }
        public Guid? UserId { get; set; }

        public string? OrderLine { get; set; }
    }
}
