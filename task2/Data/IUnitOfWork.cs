using System;
using System.Collections.Generic;
using System.Text;
using task2.Repository;

namespace task2.Data
{
	public interface IUnitOfWork
	{
		IRecipeRepository RecipeRepository { get; set; }
		ICategoryRepository CategoryRepository { get; set; }
		IIngredientRepository IngredientRepository { get; set; }
		void Save();
	}
}
