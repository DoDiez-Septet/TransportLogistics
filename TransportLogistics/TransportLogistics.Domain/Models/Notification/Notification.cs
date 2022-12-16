namespace TransportLogistics.Domain.Models.Notification
{
    /// <summary>
    /// Уведомление пользователя
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Идентификатор уведомления
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Заголовок уведомления
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Показано
        /// </summary>
        public bool IsShown { get; set; }
        /// <summary>
        /// Время создания
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Время показа пользователю
        /// </summary>
        public DateTime ShownAt { get; set; }

    }
}
