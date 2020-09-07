using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using task2.Models;

namespace task2.Repository
{
	public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
	{
		private string _filePath;
		public RecipeRepository(IList<Recipe> items, string fileName) : base(items) 
		{
			_filePath = fileName;
		}
		public IList<Recipe> GetRecipesForCategory(int categoryId)
		{
			return Items.Where(r => r.CategoryId == categoryId).ToList();
		}

		public override void Save()
		{
			var json = JsonSerializer.Serialize(Items);
			File.WriteAllText(_filePath, json);
		}

		public override Recipe Add(Recipe item)
		{
			var maxRecipeId = Items.OrderByDescending(r => r.Id).Select(r => r.Id).First();
			item.Id = maxRecipeId + 1;
			Items.Add(item);
			return item;
		}
	}
}
