using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.DataAccess.Models
{
    public abstract class TableBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
