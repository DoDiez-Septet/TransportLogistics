using Microsoft.AspNetCore.Mvc;
using TransportLogistics.Domain.Interfaces;
using TransportLogistics.Domain.Models.Points;

namespace OrderService.Controllers
{
    [Route ("api/orderservice/point")]
    public class PointController : Controller
    {
        private readonly IPointOper _pointOper;

        public PointController(IPointOper point)
        {
            _pointOper = point;
        }

        [HttpGet("/get")]
        public Task<List<IPoint>> Get()
        {
            return _pointOper.Get();
        }

        [HttpGet("/get/{name}")]
        public Task<List<IPoint>> Get(string name)
        {
            return _pointOper.Get(name);
        }

        [HttpPut("/put")]
        public Task Put(DPoint point )
        {
            return _pointOper.Add(point);
        }
        
    }
}
