

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
    internal List<Recipe> GetRecipesWithQuery(string category)
    {
        category = $"%{category}%";
        string sql = @"
        SELECT 
        rec.*, acc.* 
        FROM recipes rec 
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.category LIKE @category;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, new { category }).ToList();
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
    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes
        (title,
        instructions,
        category,
        img,
        creatorId)
        VALUES (@Title, @Instructions, @Category, @Img, @CreatorId);

        SELECT 
        rec.*, acc.* 
        FROM recipes rec 
        JOIN accounts acc ON rec.creatorId = acc.id
        WHERE rec.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
       {
           recipe.Creator = profile;
           return recipe;
       }, recipeData).FirstOrDefault();
        return recipe;
    }
    internal void EditRecipe(Recipe ogRecipe)
    {
        string sql = @"
        UPDATE recipes
        SET
        instructions = @Instructions
        WHERE id = @Id;";

        _db.Execute(sql, ogRecipe);
    }
    internal void DeleteRecipe(int recipeId)
    {
        string sql = @"DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";
        _db.Execute(sql, new { recipeId });
    }
    internal List<Recipe> GetRecipesForAccount(string userId)
    {
        string sql = @"SELECT * FROM recipes WHERE creatorId = @userId;";
        List<Recipe> recipesList = _db.Query<Recipe>(sql, new { userId }).ToList();
        return recipesList;
    }

}