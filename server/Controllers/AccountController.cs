namespace AllSpice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly FavoritesService _favoritesService;
  private readonly RecipesService _recipesService;
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService favoritesService, RecipesService recipesService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoritesService = favoritesService;
    _recipesService = recipesService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // Get favorites for account
  [Authorize]
  [HttpGet("favorites")]
  public async Task<ActionResult<List<RecipeFavorite>>> GetFavoriteRecipesForAccount()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      List<RecipeFavorite> favoritesList = _favoritesService.GetFavoriteRecipesForAccount(userId);
      return Ok(favoritesList);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  // Get Recipes for account
  [Authorize]
  [HttpGet("recipes")]
  public async Task<ActionResult<List<Recipe>>> GetRecipesForAccount()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string userId = userInfo.Id;
      List<Recipe> recipesList = _recipesService.GetRecipesForAccount(userId);
      return Ok(recipesList);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
