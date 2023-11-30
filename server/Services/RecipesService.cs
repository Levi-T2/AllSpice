using Microsoft.AspNetCore.Http.HttpResults;

namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _recipesRepository;
    public RecipesService(RecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }
    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _recipesRepository.GetRecipes();
        return recipes;
    }
    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"{recipeId} : Is invalid");
        }
        return recipe;
    }
}