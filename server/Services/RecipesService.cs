using Microsoft.AspNetCore.Http.HttpResults;

namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _recipesRepository;
    public RecipesService(RecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }
    internal List<Recipe> GetRecipes(string category)
    {
        if (category == null)
        {
            List<Recipe> recipes = _recipesRepository.GetRecipes();
            return recipes;
        }
        else
        {
            List<Recipe> recipesWithQuery = _recipesRepository.GetRecipesWithQuery(category);
            return recipesWithQuery;
        }
    }
    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _recipesRepository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"{recipeId} : Is Invalid or Null");
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
    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception($"You are not allowed to delete a Recipe not belonging to you");
        }
        _recipesRepository.DeleteRecipe(recipeId);
        return $"{recipe.Title} Has Been Deleted";
    }
    internal List<Recipe> GetRecipesForAccount(string userId)
    {
        List<Recipe> recipesList = _recipesRepository.GetRecipesForAccount(userId);
        return recipesList;
    }
}