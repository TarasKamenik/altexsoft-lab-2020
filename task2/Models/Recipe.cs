using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2.Models
{
	public class Recipe
	{
		public Recipe() { }

		public Recipe(int id, int categoryId, string name, string description, IList<Ingredient> ingredients, IList<string> steps)
		{
			#region Проверка условий
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Название рецепта не может быть пустым", nameof(name));
			}
			if (string.IsNullOrWhiteSpace(description))
			{
				throw new ArgumentNullException("Описание рецепта не может быть пустым", nameof(description));
			}
			if (ingredients.Count == 0)
			{
				throw new ArgumentNullException("Ингредиенты рецепта не могут быть пустыми", nameof(ingredients));
			}

			if (steps.Count == 0)
			{
				throw new ArgumentNullException("Название рецепта не может быть пустым", nameof(steps));
			}
			#endregion

			Id = id;
			CategoryId = categoryId;
			Name = name;
			Description = description;
			Ingredients = ingredients;
			StepsForCooking = steps;
		}

		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IList<Ingredient> Ingredients { get; set; }
		public IList<string> StepsForCooking { get; set; }

	}
}