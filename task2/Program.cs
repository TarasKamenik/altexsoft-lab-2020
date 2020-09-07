using System;
using System.Linq;
using task2.Controller;
using task2.Data;
using task2.Repository;

namespace task2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var recipeBook = new RecipeBookController(new UnitOfWork());
			recipeBook.RunRecipeBook();

			Console.ReadKey();
		}
	}
}
