using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLogistics.Domain.Models.Reports
{
    class Report
    {
        public int ReportId { get; set; }
        public Datetime DateStart { get; set; }
        public Datetime DateEnd { get; set; }
        public List<Order> Oeders { get; set; }

    }
}
