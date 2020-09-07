using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace task2.Repository
{
	interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T SingleOrDefault(Func<T, bool> predicate);
        T Add(T item);
        void Remove(T item);
        void Save();
    }
}
