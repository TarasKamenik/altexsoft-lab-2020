using System;
using System.Collections.Generic;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	public interface IService
	{
		IList<Category> GetAllCategories();
		Category GetCategory(int id);
		IList<Recipe> GetAllRecipes();
		IList<Recipe> GetRecipesForCategory(int categoryId);
		Recipe GetRecipe(int id);
		IList<Ingredient> GetAllIngredients();
		Ingredient GetIngredient(int id);
		int CreateRecipe(Recipe recipe);
	}
}
