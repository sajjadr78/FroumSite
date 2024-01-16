using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FroumSite.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AddAsync(T model);
        bool Update(T model);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);
        bool Delete(T model);
    }
}
