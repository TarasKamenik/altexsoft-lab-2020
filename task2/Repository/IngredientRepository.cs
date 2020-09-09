using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using task2.Models;

namespace task2.Repository
{
	public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
	{
		private string _filePath;
		public IngredientRepository(IList<Ingredient> items, string fileName) : base(items)
		{
			_filePath = fileName;
		}

		public override void Save()
		{
			var json = JsonSerializer.Serialize(Items);
			File.WriteAllText(_filePath, json);
		}
	}
}
