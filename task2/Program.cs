using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace task2
{
    class Program
    {
        public static List<Ingredient> IngredientList = new List<Ingredient>()
        {
            new Ingredient() { Name = "Мясо свинины" },
            new Ingredient() { Name = "Мясо говядины" },
            new Ingredient() { Name = "Соль" },
            new Ingredient() { Name = "Перец" },
            new Ingredient() { Name = "Лук" },
            new Ingredient() { Name = "Мраморная говядина" },
            new Ingredient() { Name = "Творог" },
            new Ingredient() { Name = "Банан" },
            new Ingredient() { Name = "Шоколад" },
            new Ingredient() { Name = "Мороженое" },
            new Ingredient() { Name = "Клубника" },
        };

        public static Recipe[] RecipeList = new Recipe[]
       {
            new Recipe("Название рецепта: шашлык из свинины", "Описание: вкусный и сочный шашлык из свинины", IngredientList.Where(i => i.Name == "Мясо свинины" || i.Name == "Соль" || i.Name == "Перец" || i.Name == "Лук").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
            new Recipe("Название рецепта: шашлык из говядины", "Описание: вкусный и сочный шашлык из говядины", IngredientList.Where(i => i.Name == "Мясо говядины" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
            new Recipe("Название рецепта: стейк", "Описание: рецепт сочного и невероятно вкусного стейка из говядины средней прожарки (медиум)", IngredientList.Where(i => i.Name == "Мраморная говядина" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"приготовить мясо", " посолить и поперчить мясо", "пожарить мясо"}),
            new Recipe("Название рецепта: мороженое с клубникой", "Описание: вкусное и ароматное белое мороженое с клубникой", IngredientList.Where(i => i.Name == "Мороженое" || i.Name == "Клубника").ToList(), new List<string>() {"порезать клубнику", "посыпать кусочками клубники мороженое"}),
            new Recipe("Название рецепта: мороженое с шоколадом", "Описание: вкусное и ароматное белое мороженое с шоколадом", IngredientList.Where(i => i.Name == "Мороженое" || i.Name == "Шоколад").ToList(), new List<string>() {"поломать шоколад", "посыпать кусочками шоколада мороженое"}),
            new Recipe("Название рецепта: десерт из творога с бананом и шоколадом", "Описание: очень простой и вкусный десерт", IngredientList.Where(i => i.Name == "Творог" || i.Name == "Банан"|| i.Name == "Шоколад").ToList(), new List<string>() {"порезать банан", "поломать шоколад","перемешать творог с бананом и шоколадом"})
       };

        public static List<Category> CategoryList = new List<Category>()
        {
            new Category()
            {
                Name = "Блюда из мяса",
                SubCategories = new List<Category>()
                {
                    new Category()
                    {
                        Name = " - Шашлык",
                        Recipes = new List<Recipe>()
                        {
                            new Recipe("Название рецепта: шашлык из свинины", "Описание: вкусный и сочный шашлык из свинины", IngredientList.Where(i => i.Name == "Мясо свинины" || i.Name == "Соль" || i.Name == "Перец" || i.Name == "Лук").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
                            new Recipe("Название рецепта: шашлык из говядины", "Описание: вкусный и сочный шашлык из говядины", IngredientList.Where(i => i.Name == "Мясо говядины" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"порезать мясо", "замариновать мясо", "пожарить мясо на углях"}),
                        }
                    }
                },
                Recipes = new List<Recipe>()
                {
                    new Recipe("Название рецепта: стейк", "Описание: рецепт сочного и невероятно вкусного стейка из говядины средней прожарки (медиум)", IngredientList.Where(i => i.Name == "Мраморная говядина" || i.Name == "Соль" || i.Name == "Перец").ToList(), new List<string>() {"приготовить мясо", " посолить и поперчить мясо", "пожарить мясо"}),
                }
            },
            new Category()
            {
                Name = "Десерты",
                SubCategories = new List<Category>()
                {
                    new Category()
                    {
                        Name = " - Мороженое",
                        Recipes = new List<Recipe>()
                        {
                            new Recipe("Название рецепта: мороженое с клубникой", "Описание: вкусное и ароматное белое мороженое с клубникой", IngredientList.Where(i => i.Name == "Мороженое" || i.Name == "Клубника").ToList(), new List<string>() {"порезать клубнику", "посыпать кусочками клубники мороженое"}),
                            new Recipe("Название рецепта: мороженое с шоколадом", "Описание: вкусное и ароматное белое мороженое с шоколадом", IngredientList.Where(i => i.Name == "Мороженое" || i.Name == "Шоколад").ToList(), new List<string>() {"поломать шоколад", "посыпать кусочками шоколада мороженое"})
                        }
                    }
                },
                Recipes = new List<Recipe>()
                {
                    new Recipe("Название рецепта: десерт из творога с бананом и шоколадом", "Описание: очень простой и вкусный десерт", IngredientList.Where(i => i.Name == "Творог" || i.Name == "Банан"|| i.Name == "Шоколад").ToList(), new List<string>() {"порезать банан", "поломать шоколад","перемешать творог с бананом и шоколадом"})
                }

            }
        };

        static void Main(string[] args)
        {
            
            //TransitionLogic();
            createNewRecipe(RecipeList);
        }

        public static void TransitionLogic() 
        {
            Console.WriteLine(" Кулинарная книга ");
            showAllCategories(CategoryList);
            Console.WriteLine("Общий список ингридиентов");
            Console.WriteLine("Создать рецепт");
            string menu = Console.ReadLine();
            
            if (menu == "Блюда из мяса" ^ menu == "Шашлык" ^ menu == "Десерты" ^ menu == "Мороженое")
            {

                switch (menu)
                { 
                    case "Блюда из мяса":
                        showRecipesName(RecipeList, 2);
                        string recipeName = Console.ReadLine();
                        if(recipeName != null & recipeName == "cтейк") 
                        {
                            recipeArguments(RecipeList, 2);
                        }
                        else 
                        {
                            Console.WriteLine("Выбран не верный рецепт");
                        }
                        TransitionLogic();
                    break;

                    case "Шашлык":
                        showRecipesName(RecipeList, 0);
                        showRecipesName(RecipeList, 1);
                        string recipeName2 = Console.ReadLine();
                        if (recipeName2 == "шашлык из свинины" ^ recipeName2 == "шашлык из говядины")
                        {
                            switch (recipeName2)
                            { 
                                case "шашлык из свинины":
                                recipeArguments(RecipeList, 0);
                                break;

                                case "шашлык из говядины":
                                recipeArguments(RecipeList, 1);
                                break;
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Выбран не верный рецепт");
                        }    
                        TransitionLogic();
                    break;

                    case "Десерты":
                        showRecipesName(RecipeList, 5);
                        string recipeName1 = Console.ReadLine();
                        if (recipeName1 == "десерт из творога")
                        {
                            recipeArguments(RecipeList, 5);
                        }
                        else
                        {
                            Console.WriteLine("Выбран не верный рецепт");
                        }
                        TransitionLogic();
                    break;

                    case "Мороженое":
                        showRecipesName(RecipeList, 3);
                        showRecipesName(RecipeList, 4);
                        string recipeName3 = Console.ReadLine();
                        if (recipeName3 == "мороженое с клубникой" ^ recipeName3 == "мороженое с клубникой")
                        {
                            switch (recipeName3)
                            {
                                case "мороженое с клубникой":
                                    recipeArguments(RecipeList, 3);
                                    break;

                                case "мороженое с шоколадом":
                                    recipeArguments(RecipeList, 4);
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Выбран не верный рецепт");
                        }
                        TransitionLogic();
                    break;

                    case "Общий список ингридиентов":
                        showIngridientsName(IngredientList);
                    break;

                    case "Создать рецепт":
                        createNewRecipe(RecipeList);
                    break;


                }
                
            }
            else 
            {
                Console.WriteLine("В кулинарной книге нет такой категории! Сделайте выбор ещё раз!!!!");
                TransitionLogic();
            }
        }

        public static void showAllCategories(IList<Category> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
                if (category.SubCategories.Count > 0)
                {
                    showAllCategories(category.SubCategories);
                }
            }

        }

        public static void showRecipesName(Recipe[] recipes, int i)
        {
            Console.WriteLine("Рецепт\n {0}", recipes[i].Name);
        }

        public static void recipeArguments(Recipe[] recipes, int i) 
        {
            Console.WriteLine("Рецепт\n {0},\n {1},\n {2},\n {3}", recipes[i].Name, recipes[i].Description, recipes[i].Ingredients, recipes[i].StepsForCooking);
        }

        public static void showIngridientsName(List<Ingredient> ingredients) 
        {
            foreach (var ingr in ingredients) 
            {
                Console.WriteLine(ingr.Name);
            }
        }

        public static void createNewRecipe(Recipe[] recipes) 
        {
            Console.WriteLine("Введите название рецепта");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание рецепта");
            var description = Console.ReadLine();
            Console.WriteLine("Введите ингридиенты рецепта");
            var ingredients = Console.ReadLine();
            Console.WriteLine("Введите шаги приготовления в рецепте");
            var steps = Console.ReadLine();
            Recipe newrecipe = new Recipe(name, description, new List<Ingredient> {}, new List<string> {});
            recipes.Concat(Enumerable.Repeat(newrecipe, 1)).ToArray();
            foreach (var r in recipes)
            {
                Console.WriteLine(r.Name);
            }
        }



    }

}
