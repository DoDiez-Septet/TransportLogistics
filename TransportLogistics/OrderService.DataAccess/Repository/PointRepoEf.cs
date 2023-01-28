using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Repository
{
    public class PointRepoEF : RepoEF<Point>, IPointRepoEF
    {
        public PointRepoEF(AppFactory appContext) : base(appContext)
        { }

        public override async Task<bool> Update(Point point)
        {
            var oldPoint = AllBase.FirstOrDefault(p => p.Name == point.Name);
            if (oldPoint == null)
            {
                Exception ex = new("Точка не найдена!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }

            oldPoint.Name = point.Name;
            oldPoint.Comment = point.Comment;
            await _appFactory.SaveChangesAsync();
            return true;
        }

        public override async Task<bool> Delete(Point point)
        {
            var oldPoint = AllBase.FirstOrDefault(p => p.Name == point.Name);
            if (oldPoint == null)
            {
                Exception ex = new("Точка не найдена!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }

            _appFactory.point.Remove(oldPoint);
             await _appFactory.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string pointName)
        {
            var oldPoint = AllBase.FirstOrDefault(p => p.Name == pointName);
            if (oldPoint == null)
            {
                Exception ex = new("Точка не найдена!");
                ex.Data.Add("status", HttpStatusCode.NotFound);
                throw ex;
            }

            _appFactory.point.Remove(oldPoint);
             await _appFactory.SaveChangesAsync();
            return true;
        }

    }
}
