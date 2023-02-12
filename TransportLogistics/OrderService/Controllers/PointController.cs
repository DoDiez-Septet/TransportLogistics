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
        public async Task<List<IPoint>> Get(string name)
        {
            return await _pointOper.Get(name);
        }

        [HttpPut("/put")]
        public async Task Put(Point point )
        {
            await _pointOper.Add(point);
        }

        [HttpPost("/update")]
        public async Task<bool> Update(Point point)
        {
            return await _pointOper.Update(point);
        }

        [HttpDelete("/delete")]
        public async Task<bool> Delete(string pointName)
        {
            return await _pointOper.Delete(pointName);
        }

    }
}
