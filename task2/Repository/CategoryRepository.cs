using System;
using System.Collections.Generic;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private string _filePath;
		public CategoryRepository(IList<Category> items, string fileName) : base(items) 
		{
			_filePath = fileName;
		}

		public override Category SingleOrDefault(Func<Category, bool> predicate)
		{
			return SearchCategory(predicate, Items);
		}

		public override void Save()
		{
			
		}

		private Category SearchCategory(Func<Category, bool> predicate, IList<Category> Items)
		{
			foreach (var category in Items)
			{
				if (predicate(category))
				{
					return category;
				}
				else if (category.SubCategories.Count > 0)
				{
					var result = SearchCategory(predicate, category.SubCategories);
					if (result != null && predicate(result))
						return result;
				}
			}

			return null;
		}
	}
}
