using RecipeManagement.Models;
using RecipeManagement.Services;
using System;


namespace RecipeManagementApp
{
    class Program
    {
        static RecipeServices recipeServices = new RecipeServices();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Update Recipe");
                Console.WriteLine("3. Delete Recipe");
                Console.WriteLine("4. Show All Recipes");
                Console.WriteLine("5. Exit");

                int option;
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        AddRecipeItem();
                        break;
                    case 2:
                        UpdateRecipeItem();
                        break;
                    case 3:
                        DeleteRecipeItem();
                        break;
                    case 4:
                        DisplayAllRecipes();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddRecipeItem()
        {
            Console.WriteLine("Enter Recipe Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Recipe Description:");
            string description = Console.ReadLine();

            Recipe newRecipe = new Recipe
            {
                Name = name,
                Description = description
            };

            bool success = recipeServices.AddRecipe(newRecipe);

            if (success)
            {
                Console.WriteLine("Recipe added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add recipe.");
            }
        }

        static void UpdateRecipeItem()
        {
            Console.WriteLine("Enter Recipe Name to update:");
            string name = Console.ReadLine();

            Recipe existingRecipe = recipeServices.GetAllRecipes().Find(r => r.Name == name);

            if (existingRecipe == null)
            {
                Console.WriteLine($"Recipe '{name}' not found.");
                return;
            }

            Console.WriteLine("Enter Updated Description:");
            string description = Console.ReadLine();

            existingRecipe.Description = description;

            bool success = recipeServices.UpdateRecipe(existingRecipe);

            if (success)
            {
                Console.WriteLine("Recipe updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update recipe.");
            }
        }

        static void DeleteRecipeItem()
        {
            Console.WriteLine("Enter Recipe Name to delete:");
            string name = Console.ReadLine();

            bool success = recipeServices.DeleteRecipe(name);

            if (success)
            {
                Console.WriteLine("Recipe deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete recipe '{name}'.");
            }
        }

        static void DisplayAllRecipes()
        {
            var recipes = recipeServices.GetAllRecipes();

            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                Console.WriteLine("All Recipes:");
                foreach (var recipe in recipes)
                {
                    Console.WriteLine($"Name: {recipe.Name}, Description: {recipe.Description}");
                    // Print other details if needed
                }
            }
        }
    }
}
