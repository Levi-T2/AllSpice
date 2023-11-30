



namespace AllSpice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }
    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT ing.*, acc.* 
        FROM ingredients ing
        JOIN accounts acc ON ing.creatorId = acc.id
        WHERE ing.recipeId = @recipeId;";

        List<Ingredient> ingredients = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
        {
            ingredient.Creator = profile;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredients;
    }
    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT ing.*, acc.* 
        FROM ingredients ing
        JOIN accounts acc ON ing.creatorId = acc.id
        WHERE ing.id = @ingredientId;";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
        {
            ingredient.Creator = profile;
            return ingredient;
        }, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO ingredients
        (name,
        quantity,
        creatorId,
        recipeId)
        VALUES
        (@Name,
        @Quantity,
        @CreatorId,
        @RecipeId);

        SELECT ing.*, acc.* 
        FROM ingredients ing
        JOIN accounts acc ON ing.creatorId = acc.id 
        WHERE ing.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
        {
            ingredient.Creator = profile;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }
    internal void DeleteIngredient(int ingredientId)
    {
        string sql = @"DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";
        _db.Execute(sql, new { ingredientId });
    }
}