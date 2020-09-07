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

		public Category GetCategory(int id)
		{
			return SearchCategory(id, Items);
		}

		public override void Save()
		{
			throw new NotImplementedException();
		}

		public Category SearchCategory(int id, IList<Category> Items)
		{
			foreach (var category in Items)
			{
				if (category.Id == id)
				{
					return category;
				}
				else if (category.SubCategories.Count > 0)
				{
					var result = SearchCategory(id, category.SubCategories);
					if (result != null && result.Id == id)
						return result;
				}
			}

			return null;
		}
	}
}
