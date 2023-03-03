using System.Net;
using TransportLogistics.Domain.Interfaces;
using TransportLogistics.Domain.Models.Points;

namespace OrderService.BusinessLogic.Services
{
    public class PointOper : IPointOper
    {
        private readonly IPointRepoEF _repo;
        
        public PointOper(IPointRepoEF irepo)
        {
            _repo = irepo;
        }
        
        public Task<List<IPoint>> Get(string pointname = "")
        {
            List<Point> result = string.IsNullOrEmpty(pointname) ? 
                _repo.AllBase.ToList() : 
                _repo.AllBase.Where(p => p.Name.ToLower().Contains(pointname.ToLower())).ToList();

            List<IPoint> resultList = new List<IPoint>();
            result.ForEach(p => resultList.Add(p));

            return Task.FromResult(resultList);
        }

        public async Task Add(IPoint point)
        {
            Point tPoint = new()
            {
                Name = point.Name,
                Comment = point.Comment
            };
            
            int nameCount = _repo.AllBase.Count(p => p.Name.ToLower() == point.Name.ToLower());
            if (nameCount > 0)
            {
                
                Exception ex = new("Точка с таким именем уже существует!");
                ex.Data.Add("status", HttpStatusCode.Conflict);
                throw ex;
            }
            
            await _repo.Add(tPoint);
        }

        public async Task<bool> Update(IPoint point)
        {
            Point tPoint = new()
            {
                Name = point.Name,
                Comment = point.Comment
            };
            return await _repo.Update(tPoint);
        }

        public async Task<bool> Delete(string pointName)
        {
            return await _repo.Delete(pointName);
        }
    }
}
