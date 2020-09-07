using System;
using System.Collections.Generic;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	interface ICategoryRepository
	{
		Category SearchCategory(int id, IList<Category> categories);
	}
}
