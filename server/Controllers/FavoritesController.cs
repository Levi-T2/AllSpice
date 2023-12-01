namespace AllSpice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;
    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _favoritesService = favoritesService;
        _auth0Provider = auth0Provider;
    }

    // Get Favorite by Id
    [HttpGet("{favoriteId}")]
    public ActionResult<Favorite> GetFavoriteById(int favoriteId)
    {
        try
        {
            Favorite favorite = _favoritesService.GetFavoriteById(favoriteId);
            return Ok(favorite);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // Create Favorite
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            Favorite favorite = _favoritesService.CreateFavorite(favoriteData);
            return Ok(favorite);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    // Delete Favorite
    [Authorize]
    [HttpDelete("{favoriteId}")]
    public async Task<ActionResult<Favorite>> DeleteFavorite(int favoriteId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _favoritesService.DeleteFavorite(favoriteId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}

