



namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;
    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }
    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"SELECT * FROM favorites WHERE id = @favoriteId";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
       INSERT INTO favorites 
       (accountId, recipeId) 
       VALUES (@accountId, @recipeId);
       
       SELECT * FROM favorites WHERE id = LAST_INSERT_ID();";

        Favorite favorite = _db.Query<Favorite>(sql, favoriteData).FirstOrDefault();
        return favorite;
    }
    internal void DeleteFavorite(int favoriteId)
    {
        string sql = @"DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";
        _db.Execute(sql, new { favoriteId });
    }
    internal List<RecipeFavorite> GetFavoriteRecipesForAccount(string userId)
    {
        string sql = @"
        SELECT fav.*, rec.*, acc.* 
        FROM favorites fav
        JOIN recipes rec ON fav.recipeId = rec.id
        JOIN accounts acc ON acc.id = rec.creatorId
        WHERE accountId = @userId;";

        List<RecipeFavorite> favoritesList = _db.Query<Favorite, RecipeFavorite, Profile, RecipeFavorite>(sql, (favorite, recipeFavorite, profile) =>
        {
            recipeFavorite.FavoriteId = favorite.Id;
            recipeFavorite.AccountId = favorite.AccountId;
            recipeFavorite.Creator = profile;
            return recipeFavorite;
        }, new { userId }).ToList();
        return favoritesList;
    }
}