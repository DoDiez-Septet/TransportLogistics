using TransportLogistics.Domain.Enums.Orders;

namespace TransportLogistics.Domain.Models.Orders
{
    /// <summary>
    /// Класс Заказа на перевозку
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор заказ
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Комментарии к заказу
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Пункт отправки заказа
        /// </summary>
        public string PointOfDeparture { get; set; }

        /// <summary>
        /// Пункт получения заказа
        /// </summary>
        public string PointOfDestination { get; set; }

        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ссылка на заказчика
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}