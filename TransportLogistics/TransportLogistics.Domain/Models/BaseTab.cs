using System.ComponentModel.DataAnnotations;

namespace TransportLogistics.Domain.Models
{
    public class BaseTab
    {
        [Key]
        public Guid Id { get; set; }
    }
}
