using System;
using System.Collections.Generic;
using System.Text;
using task2.Models;

namespace task2.Repository
{
	interface IIngredientRepository 
	{
		Ingredient GetIngredient(int id);
	}
	


}
