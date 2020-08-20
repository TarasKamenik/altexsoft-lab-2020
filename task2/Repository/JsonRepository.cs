using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using task2.Models;

namespace task2.Repository
{
	public class JsonRepository : IRepository
	{
		private static string _ingredientsFile = "ingredients.json";
		private static string _recipesFile = "recipes.json";
		private static string _categoriesFile = "categories.json";

		private readonly string _storagePath;
		private readonly List<Ingredient> _ingredientList;
		private readonly List<Recipe> _recipeList;
		private readonly List<Category> _categoryList;

		public JsonRepository(string storagePath, InMemoryRepository inMemoryRepository = null)
		{
			_storagePath = storagePath;
			_ingredientList = ResolveEntitiesFile(Path.Combine(storagePath, _ingredientsFile), inMemoryRepository?.GetAllIngredients());
			_recipeList = ResolveEntitiesFile(Path.Combine(storagePath, _recipesFile), inMemoryRepository?.GetAllRecipes());
			_categoryList = ResolveEntitiesFile(Path.Combine(storagePath, _categoriesFile), inMemoryRepository?.GetAllCategories());
		}

		public int CreateRecipe(Recipe recipe)
		{
			var maxRecipeId = _recipeList.OrderByDescending(r => r.Id).Select(r => r.Id).First();
			recipe.Id = maxRecipeId + 1;
			_recipeList.Add(recipe);
			var json = JsonSerializer.Serialize(_recipeList);
			File.WriteAllText(Path.Combine(_storagePath, _recipesFile), json);
			return recipe.Id;
		}

		public IList<Category> GetAllCategories()
		{
			return _categoryList;
		}

		public IList<Ingredient> GetAllIngredients()
		{
			return _ingredientList;
		}

		public IList<Recipe> GetAllRecipes()
		{
			return _recipeList;
		}

		public Category GetCategory(int id)
		{
			return SearchCategory(id, _categoryList);
		}

		public Ingredient GetIngredient(int id)
		{
			return _ingredientList.FirstOrDefault(i => i.Id == id);
		}

		public Recipe GetRecipe(int id)
		{
			return _recipeList.FirstOrDefault(r => r.Id == id);
		}

		public IList<Recipe> GetRecipesForCategory(int categoryId)
		{
			return _recipeList.Where(r => r.CategoryId == categoryId).ToList();
		}

		private Category SearchCategory(int id, IList<Category> categories)
		{
			foreach (var category in categories)
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
