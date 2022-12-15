using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Models
{
    public class OrderLine : TableBase
    {
        public string Description { get; set; }
    }
}
