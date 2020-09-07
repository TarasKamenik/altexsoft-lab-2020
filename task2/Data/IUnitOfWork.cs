using System;
using System.Collections.Generic;
using System.Text;
using task2.Repository;

namespace task2.Data
{
	public interface IUnitOfWork
	{
		RecipeRepository RecipeRepository { get; set; }
		CategoryRepository CategoryRepository { get; set; }
		IngredientRepository IngredientRepository { get; set; }
	}
}
