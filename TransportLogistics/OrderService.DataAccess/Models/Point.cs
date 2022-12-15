using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Models
{
    public class Point : TableBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Comment { get; set; }
    }
}
