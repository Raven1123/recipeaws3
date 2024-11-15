using System;
using System.Collections.Generic;
using RecipeManagement.Models;
using RecipeManagement.Data;

namespace RecipeManagement.Services

{
    public class RecipeServices
    {
        private RecipeData _recipeData;

        public RecipeServices()
        {
            _recipeData = new RecipeData();
        }

        public bool AddRecipe(Recipe recipe)
        {
            try
            {
                int rowsAffected = _recipeData.AddRecipe(recipe);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding recipe: {ex.Message}");
                return false;
            }
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            try
            {
                int rowsAffected = _recipeData.UpdateRecipe(recipe);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating recipe: {ex.Message}");
                return false;
            }
        }

        public bool DeleteRecipe(string Recipe)
        {
            try
            {
               int rowsAffected = _recipeData.DeleteRecipe(Recipe);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting recipe: {ex.Message}");
                return false;
            }
        }

        public List<Recipe> GetAllRecipes()
        {
            try
            {
                return _recipeData.GetRecipes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving recipes: {ex.Message}");
                return new List<Recipe>(); 
            }
        }
    }
}
