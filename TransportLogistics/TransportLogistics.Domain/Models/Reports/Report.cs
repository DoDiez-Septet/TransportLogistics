using TransportLogistics.Domain.Models.Orders;

namespace TransportLogistics.Domain.Models.Reports
{
    class Report
    {
        public int ReportId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<Order> Orders { get; set; }
    }
}
