using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace FroumSite.Data.Abstractions
{
    public interface IBaseRepository<T> : IDisposable
             where T : TableData, new()
    {
        void SaveItem(T item);
        T GetItem(int id);
        List<T> GetItems();
        void DeleteItem(T item);
        void Update(T item);
    }
}
