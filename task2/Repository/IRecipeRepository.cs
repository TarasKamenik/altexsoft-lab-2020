using System;
using System.Collections.Generic;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	public interface IRecipeRepository : IGenericRepository<Recipe>
	{
		IList<Recipe> GetRecipesForCategory(int categoryId);
	}
}
