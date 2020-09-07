using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace task2.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected List<T> Items { get; set; }
        public GenericRepository(IList<T> items) 
        {
            Items = items.ToList();
        }
        public virtual T Add(T item)
        {
            Items.Add(item);
            return item;
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Items.Where(predicate);
        }
                
        public virtual IEnumerable<T> GetAll()
        {
            return Items;
        }

        public virtual void Remove(T item)
        {
            Items.Remove(item);
        }

        public abstract void Save();
		
		public virtual T SingleOrDefault(Func<T, bool> predicate)
        {
            return Items.SingleOrDefault(predicate);
        }
    }
}
