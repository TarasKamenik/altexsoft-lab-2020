using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace task2.Data
{
	public class FileManager
	{
		public string IngredientsFile { get; } = "ingredients.json";
		public string RecipesFile { get; } = "recipes.json";
		public string CategoriesFile { get; } = "categories.json";

		public List<T> ResolveEntitiesFile<T>(string path, IList<T> entities)
		{
			InitDataIfNotExist(path, entities);
			if (!File.Exists(path))
			{
				throw new Exception($"Нет файла {path}");
			}

			return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
		}

		private void InitDataIfNotExist<T>(string path, IList<T> entities)
		{
			if (!File.Exists(path) && entities != null)
			{
				var json = JsonSerializer.Serialize(entities);
				File.WriteAllText(path, json);
			}
		}
	}
}
