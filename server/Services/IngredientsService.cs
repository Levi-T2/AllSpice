


namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;
    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }
    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _ingredientsRepository.GetIngredientById(ingredientId);
        if (ingredient == null)
        {
            throw new Exception($"{ingredient.Id} : Is Invalid or Null ");
        }
        return ingredient;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _ingredientsRepository.CreateIngredient(ingredientData);
        return ingredient;
    }
    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        if (ingredient.CreatorId != userId)
        {
            throw new Exception("You are not allowed to delete an ingredient that doesn't belong to you.");
        }
        _ingredientsRepository.DeleteIngredient(ingredientId);
        return $"{ingredient.Id} Has Been Deleted;";
    }
    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}