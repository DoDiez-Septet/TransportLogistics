using TransportLogistics.Domain.Interfaces;

namespace TransportLogistics.Domain.Models.Points
{
    public class Point : BaseTab, IPoint
    {
       
        public string Name { get; set; }
        public string? Comment { get; set; }
    }
}
