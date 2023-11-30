
namespace AllSpice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
        _db = db;

    }
    internal List<Recipe> GetRecipes()
    {
        string sql = @"
        SELECT 
        rec.*, acc.* 
        FROM recipes rec 
        JOIN accounts acc ON rec.creatorId = acc.id;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();
        return recipes;
    }
    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT 
        rec.*, acc.* 
        FROM recipes rec 
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;


    }
}