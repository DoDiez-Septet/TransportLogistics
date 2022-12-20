using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.DataAccess.Models
{
    public class Notification : TableBase
    {
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
