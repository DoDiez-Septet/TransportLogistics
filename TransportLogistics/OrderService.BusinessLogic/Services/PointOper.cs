using System.Net;

namespace OrderService.BusinessLogic.Services
{
    public class PointOper : IPointOper
    {
        private readonly IRepository<Point> _repo;
        
        public PointOper(IRepository<Point> irepo)
        {
            _repo = irepo;
        }
        
        public Task<List<IPoint>> Get(string pointname = "")
        {
            List<Point> result = string.IsNullOrEmpty(pointname) ? 
                _repo.AllBase.ToList() : 
                _repo.AllBase.Where(p => p.Name.ToLower().Contains(pointname.ToLower())).ToList();

            List<IPoint> resultList = new List<IPoint>();
            result.ForEach(p => resultList.Add(TPoint.Convert(p)));

            return Task.FromResult(resultList);
        }

        public async Task Add(IPoint point)
        {
            TPoint tPoint = new()
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
            var oldPoint = _repo.AllBase.FirstOrDefault(p => p.Name == point.Name);
            if (oldPoint == null)
            {
                Exception ex = new("Точка не найдена!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }

            oldPoint.Name = point.Name;
            oldPoint.Comment = point.Comment;
            return await _repo.Update(oldPoint);
        }
    }
}
