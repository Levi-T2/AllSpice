


namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;
    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }
    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _favoritesRepository.GetFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"{favorite.Id} :Is Invalid or Null");
        }
        return favorite;
    }
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _favoritesRepository.CreateFavorite(favoriteData);
        return favorite;
    }
    internal string DeleteFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);
        if (favorite.AccountId != userId)
        {
            throw new Exception("Can't delete a favorite that doesn't belong to you!");
        }
        _favoritesRepository.DeleteFavorite(favoriteId);
        return $"{favorite.Id} Has Been Deleted!";

    }
    internal List<RecipeFavorite> GetFavoriteRecipesForAccount(string userId)
    {
        List<RecipeFavorite> favoritesList = _favoritesRepository.GetFavoriteRecipesForAccount(userId);
        return favoritesList;
    }
}