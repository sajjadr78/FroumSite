using FroumSite.Data;
using FroumSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FroumSite.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private FroumContext _context;
        DbSet<T> _entity = null;
        public GenericRepository(FroumContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T model)
        {
            try
            {
                await _entity.AddAsync(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T model)
        {
            try
            {
                _entity.Remove(model);
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public bool Update(T model)
        {
            try
            {

                _context.Entry(model).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> SaveChangesAsync()
        {
            try
            {

                return _context.SaveChangesAsync().Result.ToString();
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
    }
}
