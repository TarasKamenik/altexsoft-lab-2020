using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task2.Models;
using task2.Repository;

namespace task2.Controller
{
	public class RecipeBookController
	{
		private readonly IRepository _repository;

		public RecipeBookController(IRepository repository)
		{
			_repository = repository;
		}

		public void RunRecipeBook()
		{
			Console.WriteLine("--------------------");
			Console.WriteLine("- Кулинарная книга -");
			Console.WriteLine("--------------------");

			ShowControls();

			string input = null;
			var categoryIdStack = new Stack<int>();
			ShowCategoryContent(null);
			while (input != "Exit")
			{
				input = Console.ReadLine();
				switch (input)
				{
					case "I":
					case "Ingredients":
						ShowIngridients();
						break;
					case "N":
					case "New":
						if (categoryIdStack.Count > 0)
						{
							CreateNewRecipeInCategory(categoryIdStack.Peek());
						} 
						else
						{
							Console.WriteLine("В корневом каталоге нельзя создать рецепт, выберите категорию.");
						}
						break;
					case "B":
					case "Back":
						if (categoryIdStack.Count > 0)
						{
							categoryIdStack.Pop();
							ShowCategoryContent(categoryIdStack.Count > 0 ? (int?)categoryIdStack.Peek() : null);
						}
						break;
					case "H":
					case "Help":
						ShowControls();
						break;
					case "Exit":
						break;
					case "C":
					case "Current":
						ShowCategoryContent(categoryIdStack.Count > 0 ? (int?)categoryIdStack.Peek() : null);
						break;
					default:
						if (input.StartsWith("C"))
						{
							var idStr = input.Substring(1, input.Length - 1);
							if (int.TryParse(idStr, out int id))
							{
								var category = _repository.GetCategory(id);
								if (category != null)
								{
									categoryIdStack.Push(category.Id);
									ShowCategoryContent(categoryIdStack.Peek());
								} 
								else
								{
									Console.WriteLine("Неверный выбор, попробуйте еще раз.");
								}
							}
						}
						else if (input.StartsWith("R"))
						{
							var idStr = input.Substring(1, input.Length - 1);
							if (int.TryParse(idStr, out int id))
							{
								var recipe = _repository.GetRecipe(id);
								if (recipe != null)
								{
									Console.WriteLine(FormatRecipe(recipe));
								}
								else
								{
									Console.WriteLine("Неверный выбор, попробуйте еще раз.");
								}
							}
						}
						else
						{
							Console.WriteLine("Неверный выбор, попробуйте еще раз.");
						}
						break;
				}
			}

		}

		private void ShowControls()
		{
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine("I, Ingredients - Общий список ингридиентов");
			Console.WriteLine("N, New - Создать рецепт в текущей категории");
			Console.WriteLine("C, Current - Текущая категорию");
			Console.WriteLine("C1-9 - Выбрать категорию");
			Console.WriteLine("R1-9 - Выбрать рецепт");
			Console.WriteLine("B, Back - Вернуться назад");
			Console.WriteLine("H, Help - Управление");
			Console.WriteLine("Exit - Выход");
			Console.WriteLine("--------------------------------------------");
		}

		private void ShowCategoryContent(int? categoryId)
		{

			if (categoryId == null)
			{
				var categories = _repository.GetAllCategories();
				foreach (var category in categories)
				{
					Console.WriteLine($"C{category.Id} - Категория: {category.Name}");
				}
			}
			else
			{
				var category = _repository.GetCategory(categoryId.Value);
				foreach (var subCategory in category.SubCategories)
				{
					Console.WriteLine($"C{subCategory.Id} - Категория: {subCategory.Name}");
				}
				var recipes = _repository.GetRecipesForCategory(category.Id);
				foreach (var recipe in recipes)
				{
					Console.WriteLine($"R{recipe.Id} - Рецепт: {recipe.Name}");
				}
			}
		}

		private void ShowIngridients()
		{
			var ingridients = _repository.GetAllIngredients();
			foreach (var ingridient in ingridients)
			{
				Console.WriteLine($"{ingridient.Id} - {ingridient.Name}");
			}
		}

		private static string FormatRecipe(Recipe recipe)
		{
			return $"Рецепт\n {recipe.Name},\n {recipe.Description},\n {string.Join(",", recipe.Ingredients.Select(i => i.Name))},\n {string.Join(",", recipe.StepsForCooking)}";
		}

		private void CreateNewRecipeInCategory(int categoryId)
		{
			Console.Write("Введите название рецепта: ");
			var name = Console.ReadLine();
			Console.Write("Введите описание рецепта: ");
			var description = Console.ReadLine();
			ShowIngridients();
			Console.WriteLine("Введите номера ингридиентов рецепта через запятую: ");
			var ingredientNumbers = Console.ReadLine().Split(",");
			var ingredients = ingredientNumbers
				.Where(i => int.TryParse(i, out int intId))
				.Select(i => _repository.GetIngredient(int.Parse(i)))
				.Where(i => i != null)
				.ToList();
			Console.WriteLine("Введите шаги приготовления в рецепте через точку с запятой (;): ");
			var steps = Console.ReadLine().Split(";");
			var newRecipe = new Recipe(-1, categoryId, name, description, ingredients, steps.ToList());
			_repository.CreateRecipe(newRecipe);
			Console.WriteLine("Новый рецепт добавлен!");
		}
	}
}
