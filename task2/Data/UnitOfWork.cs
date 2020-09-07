using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using task2.Models;
using task2.Repository;

namespace task2.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		public RecipeRepository RecipeRepository { get; set; }
		public CategoryRepository CategoryRepository { get; set; }
		public IngredientRepository IngredientRepository { get; set; }

		private static string _ingredientsFile = "ingredients.json";
		private static string _recipesFile = "recipes.json";
		private static string _categoriesFile = "categories.json";

		public UnitOfWork() 
		{
			var storagePath = AppDomain.CurrentDomain.BaseDirectory;
			var inMemoryService = new InMemoryService();
			var ingredientList = ResolveEntitiesFile(Path.Combine(storagePath, _ingredientsFile), inMemoryService?.GetAllIngredients());
			var recipeList = ResolveEntitiesFile(Path.Combine(storagePath, _recipesFile), inMemoryService?.GetAllRecipes());
			var categoryList = ResolveEntitiesFile(Path.Combine(storagePath, _categoriesFile), inMemoryService?.GetAllCategories());

			RecipeRepository = new RecipeRepository(recipeList, _recipesFile);
			CategoryRepository = new CategoryRepository(categoryList, _categoriesFile);
			IngredientRepository = new IngredientRepository(ingredientList, _ingredientsFile);
		}
		private List<T> ResolveEntitiesFile<T>(string path, IList<T> entities)
		{
			if (!File.Exists(path) && entities != null)
			{
				var json = JsonSerializer.Serialize(entities);
				File.WriteAllText(path, json);
			}

			if (!File.Exists(path))
			{
				throw new Exception($"Нет файла {path}");
			}

			return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
		}
	}
}
