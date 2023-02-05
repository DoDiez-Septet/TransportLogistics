using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TransportLogistics.Domain.Enums.Users;

namespace UserService.DataAccess.ModelDb;

/// <summary>
/// Класс Пользователь, объект базы данных
/// </summary>
internal class UserDb
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Email пользователя
    /// </summary>
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    [Required]
    [MaxLength(30)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Роль пользователя
    /// </summary>
    public UserRole Role { get; set; }
}