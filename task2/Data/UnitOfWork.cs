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
		public IRecipeRepository RecipeRepository { get; set; }
		public ICategoryRepository CategoryRepository { get; set; }
		public IIngredientRepository IngredientRepository { get; set; }
		private readonly FileManager _fileManager;

		public UnitOfWork()
		{
			var storagePath = AppDomain.CurrentDomain.BaseDirectory;
			var inMemoryService = new InMemoryService();
			_fileManager = new FileManager();
			var ingredientList = _fileManager.ResolveEntitiesFile(Path.Combine(storagePath, _fileManager.IngredientsFile), inMemoryService?.GetAllIngredients());
			var recipeList = _fileManager.ResolveEntitiesFile(Path.Combine(storagePath, _fileManager.RecipesFile), inMemoryService?.GetAllRecipes());
			var categoryList = _fileManager.ResolveEntitiesFile(Path.Combine(storagePath, _fileManager.CategoriesFile), inMemoryService?.GetAllCategories());

			RecipeRepository = new RecipeRepository(recipeList, _fileManager.IngredientsFile);
			CategoryRepository = new CategoryRepository(categoryList, _fileManager.RecipesFile);
			IngredientRepository = new IngredientRepository(ingredientList, _fileManager.CategoriesFile);
		}

		public void Save()
		{
			RecipeRepository.Save();
			CategoryRepository.Save();
			IngredientRepository.Save();
		}
		
	}
}
