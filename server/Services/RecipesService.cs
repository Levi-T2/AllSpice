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
    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _recipesRepository.CreateRecipe(recipeData);
        return recipe;
    }
    internal Recipe EditRecipe(int recipeId, Recipe recipeData)
    {
        Recipe ogRecipe = GetRecipeById(recipeId);

        ogRecipe.Instructions = recipeData.Instructions ?? ogRecipe.Instructions;

        _recipesRepository.EditRecipe(ogRecipe);
        return ogRecipe;
    }
    internal Recipe DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception($"You are not allowed to delete a Recipe not belonging to you");
        }
        _recipesRepository.DeleteRecipe(recipeId);
        return $"{recipe.Title} Has Been Destroyed";
    }
}