namespace CustomerService.DataAccess.Models
{
    public interface IEntity<TId>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        TId Id { get; set; }
    }
}
