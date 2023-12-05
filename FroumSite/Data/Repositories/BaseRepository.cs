using FroumSite.Data.Abstractions;
using System.Collections.Generic;

namespace FroumSite.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        FroumContext _context;
        public BaseRepository(FroumContext context)
        {
            _context = context;
        }
        public void DeleteItem(T item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public T GetItem(int id)
        {
            return _context.Find<T>(id);
        }

        public List<T> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void SaveItem(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
