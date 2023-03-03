
namespace TransportLogistics.Domain.Interfaces
{
    public interface IPoint
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Comment { get; set; }
    }
}
