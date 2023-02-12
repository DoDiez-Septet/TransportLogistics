using TransportLogistics.Domain.Enums.Users;

namespace TransportLogistics.Domain.Models.Users
{
    /// <summary>
    /// Класс Пользователь
    /// </summary>
    public class User :BaseTab
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email пользователя
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public UserRole Role { get; set; }
    }
}