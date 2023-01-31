using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.DataAccess.Models
{
    public class Customer : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор заказчика
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование заказчика
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Телефон заказчика
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email заказчика
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Адрес заказчика
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Контактное лицо заказчика
        /// </summary>
        public string ContactPerson { get; set; }
    }
}
