using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task2.Models
{
	public class Category
	{
		public Category()
		{
			SubCategories = new List<Category>();
			Recipes = new List<Recipe>();
		}

		public Category(int id, string name)
		{
			Id = id;
			Name = name;
			SubCategories = new List<Category>();
			Recipes = new List<Recipe>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public IList<Recipe> Recipes { get; set; }
		public IList<Category> SubCategories { get; set; }
	}
}
