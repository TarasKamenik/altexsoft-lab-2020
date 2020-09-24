using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text.Json;
using System.IO;

namespace task2.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected string FilePath { get; set; }
        protected List<T> Items { get; set; }
        public GenericRepository(IList<T> items, string fileName) 
        {
            Items = items.ToList();
            FilePath = fileName;
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

        public virtual void Save()
        {
            var json = JsonSerializer.Serialize(Items);
            File.WriteAllText(FilePath, json);
        }

        public virtual T SingleOrDefault(Func<T, bool> predicate)
        {
            return Items.SingleOrDefault(predicate);
        } 
    }
}
