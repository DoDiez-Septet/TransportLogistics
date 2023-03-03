using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Models
{
    public abstract class TableBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
