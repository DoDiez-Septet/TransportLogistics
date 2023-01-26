global using OrderService.DataAccess.Models;
global using TransportLogistics.Domain.Interfaces;

namespace OrderService.BusinessLogic.Models
{
    public class TPoint : Point, IPoint
    {
        public static TPoint Convert(Point point)
        {
            return new TPoint
            {
                Name = point.Name,
                Comment = point.Comment
            };
        }

        public static Point Convert(TPoint tpoint)
        {
            return tpoint;
        }
    }
}
