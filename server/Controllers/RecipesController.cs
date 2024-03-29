namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;
    private readonly Auth0Provider _auth0Provider;
    private readonly IngredientsService _ingredientsService;
    public RecipesController(RecipesService recipesService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
    {
        _recipesService = recipesService;
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;
    }

    // Get All Recipes
    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes(string category)
    {
        try
        {
            List<Recipe> recipes = _recipesService.GetRecipes(category);
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // Get Recipe By Id
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

    // Create Recipe
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

    // Edit Recipe
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

    // Delete Recipe
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

    //  Get Ingredients By Recipe Id
    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
