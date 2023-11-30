namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0Provider;
    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetRecipes();
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.CreateRecipe(recipeData);
            return Ok(recipe);

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpPut("{recipeId}")]
    public async Task<ActionResult<Recipe>> EditRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipesService.EditRecipe(recipeId, recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [Authorize]
    [HttpDelete("{recipeId}")]
    public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _recipesService.DeleteRecipe(recipeId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
