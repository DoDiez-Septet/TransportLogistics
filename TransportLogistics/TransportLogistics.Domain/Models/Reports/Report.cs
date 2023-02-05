using TransportLogistics.Domain.Models.Orders;

namespace TransportLogistics.Domain.Models.Reports
{
    /// <summary>
    /// Класс Отчеты по заказу
    /// </summary>
    class Report
    {
        /// <summary>
        /// Идентификатор отчета
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime DateEnd { get; set; }
        
        /// <summary>
        /// Заказы в отчете
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
