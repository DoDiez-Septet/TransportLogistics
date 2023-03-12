using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.DataAccess.Models
{
    internal class CustomerDb
    {
        /// <summary>
        /// Идентификатор заказчика
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование заказчика
        /// </summary>
        [Required]
        [MaxLength(200)]
        [MinLength(6)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Телефон заказчика
        /// </summary>
        [Required]
        [MaxLength(16)]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Email заказчика
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Адрес заказчика
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Контактное лицо заказчика
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string ContactPerson { get; set; } = string.Empty;
    }
}
