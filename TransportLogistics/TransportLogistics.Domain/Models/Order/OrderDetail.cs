namespace TransportLogistics.Domain.Models.Order
{
    /// <summary>
    /// Класс Грузы в первозке
    /// </summary>
    public class OrderDetail :BaseTab
    {
        /// <summary>
        /// Идентификатор груза
        /// </summary>
        //public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на заказ
        /// </summary>
        //public Guid OrderId { get; set; }

        /// <summary>
        /// Описание груза
        /// </summary>
        public string UnitDescription { get; set; }

        /// <summary>
        /// Цена перевозки груза
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Ширина в см - поэтому используем целое число
        /// </summary>
        public int Widtht { get; set; }

        /// <summary>
        /// Высота грузагруза в см - поэтому используем целое число
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Длина груза в см - поэтому используем целое число
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Вес груза в кг
        /// </summary>
        public int Weight { get; set; }
    }
}