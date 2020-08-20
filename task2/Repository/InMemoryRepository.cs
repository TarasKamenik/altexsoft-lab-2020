using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	public class InMemoryRepository : IRepository
	{
		private static List<Ingredient> _ingredientList = new List<Ingredient>()
		{
			new Ingredient() { Id = 1, Name = "Мясо свинины" },
			new Ingredient() { Id = 2, Name = "Мясо говядины" },
			new Ingredient() { Id = 3, Name = "Соль" },
			new Ingredient() { Id = 4, Name = "Перец" },
			new Ingredient() { Id = 5, Name = "Лук" },
			new Ingredient() { Id = 6, Name = "Мраморная говядина" },
			new Ingredient() { Id = 7, Name = "Творог" },
			new Ingredient() { Id = 8, Name = "Банан" },
			new Ingredient() { Id = 9, Name = "Шоколад" },
			new Ingredient() { Id = 10, Name = "Мороженое" },
			new Ingredient() { Id = 11, Name = "Клубника" },
		};

		private static List<Recipe> _recipeList = new List<Recipe>
		{
			new Recipe(1, 2, "шашлык из свинины", "вкусный и сочный шашлык из свинины",
				_ingredientList.Where(i => i.Name == "Мясо свинины" || i.Name == "Соль" || i.Name == "Перец" || i.Name == "Лук").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
			new Recipe(2, 2, "шашлык из говядины", "вкусный и сочный шашлык из говядины",
				_ingredientList.Where(i => i.Name == "Мясо говядины" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
			new Recipe(3, 1, "стейк", "рецепт сочного и невероятно вкусного стейка из говядины средней прожарки (медиум)",
				_ingredientList.Where(i => i.Name == "Мраморная говядина" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"приготовить мясо", " посолить и поперчить мясо", "пожарить мясо"}),
			new Recipe(4, 4, "мороженое с клубникой", "вкусное и ароматное белое мороженое с клубникой",
				_ingredientList.Where(i => i.Name == "Мороженое" || i.Name == "Клубника").ToList(), new List<string>() {"порезать клубнику", "посыпать кусочками клубники мороженое"}),
			new Recipe(5, 4, "мороженое с шоколадом", "вкусное и ароматное белое мороженое с шоколадом",
				_ingredientList.Where(i => i.Name == "Мороженое" || i.Name == "Шоколад").ToList(), new List<string>() {"поломать шоколад", "посыпать кусочками шоколада мороженое"}),
			new Recipe(6, 3, "десерт из творога с бананом и шоколадом", "очень простой и вкусный десерт",
				_ingredientList.Where(i => i.Name == "Творог" || i.Name == "Банан"|| i.Name == "Шоколад").ToList(), new List<string>() {"порезать банан", "поломать шоколад","перемешать творог с бананом и шоколадом"})
		};

		private static List<Category> _categoryList = new List<Category>()
		{
			new Category(1, "Блюда из мяса")
			{

				SubCategories = new List<Category>()
				{
					new Category(2, "Шашлык")
				}
			},
			new Category(3, "Десерты")
			{
				SubCategories = new List<Category>()
				{
					new Category(4, "Мороженое")
				}

			}
		};

		public int CreateRecipe(Recipe recipe)
		{
			var maxRecipeId = _recipeList.OrderByDescending(r => r.Id).Select(r => r.Id).First();
			recipe.Id = maxRecipeId + 1;
			_recipeList.Add(recipe);
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
	}
}
