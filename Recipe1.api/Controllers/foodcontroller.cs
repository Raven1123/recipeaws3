using Microsoft.AspNetCore.Mvc;
using RecipeManagement.Models; 
using RecipeManagement.Services; 

namespace Name.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class foodController : ControllerBase
    {
        private readonly RecipeServices _recipeServices;

        public foodController()
        {
            _recipeServices = new RecipeServices();
        }

        // GET: api/info
        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            var recipes = _recipeServices.GetAllRecipes();
            return Ok(recipes);
        }

        // POST: api/info
        [HttpPost]
        public ActionResult AddRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Recipe object is null");
            }

            if (_recipeServices.AddRecipe(recipe))
            {
                return CreatedAtAction(nameof(GetAllRecipes), new { name = recipe.Name }, recipe);
            }
            else
            {
                return StatusCode(500, "Error adding recipe");
            }
        }

        // PATCH: api/info/{infoName}
        [HttpPatch("{recipeName}")]
        public ActionResult UpdateRecipe(string recipeName, [FromBody] Recipe recipe)
        {
            if (recipe == null || recipe.Name != recipe.Name)
            {
                return BadRequest("Recipe object or name mismatch");
            }

            if (_recipeServices.UpdateRecipe(recipe))
            {
                return Ok(recipe);
            }
            else
            {
                return StatusCode(500, $"Error updating info with name {recipeName}");
            }
        }

        // DELETE: api/info/{infoName}
        [HttpDelete("{recipeName}")]
        public ActionResult DeleteRecipe(string recipeName)
        {
            if (_recipeServices.DeleteRecipe(recipeName))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, $"Error deleting info with name {recipeName}");
            }
        }
    }
}
