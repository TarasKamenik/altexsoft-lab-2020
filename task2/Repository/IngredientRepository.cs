using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
	{
		private string _filePath;
		public IngredientRepository(IList<Ingredient> items, string fileName) : base(items)
		{
			_filePath = fileName;
		}

		public override void Save()
		{
			throw new NotImplementedException();
		}

		public Ingredient GetIngredient(int id)
		{
			return Items.FirstOrDefault(i => i.Id == id);
		}
	}
}
