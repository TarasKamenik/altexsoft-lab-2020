using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using task2.Models;

namespace task2.Repository
{
	public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
	{
		public IngredientRepository(IList<Ingredient> items, string fileName) : base(items, fileName)
		{
			
		}
	}
}
