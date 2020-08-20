using System;
using System.Linq;
using task2.Controller;

namespace task2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var recipeBook = new RecipeBookController();
			recipeBook.RunRecipeBook();

			Console.ReadKey();
		}
	}
}
