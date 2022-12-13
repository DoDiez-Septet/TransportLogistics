namespace TransportLogistics.Domain.Models.Customers
{
    /// <summary>
    /// Класс Заказчик
    /// </summary>
    internal class Customer
    {
        /// <summary>
        /// Идентификатор заказчика
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименования заказчика
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