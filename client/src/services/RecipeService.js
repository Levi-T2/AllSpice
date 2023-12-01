import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipeService 
{
    async GetRecipes()
    {
        const res = await api.get("api/recipes")
        const newRecipes = res.data.map((recipes) => new Recipe(recipes))
        AppState.recipes = newRecipes
        logger.log(`[RECIPE SERVICE] These are the recipes in the AppState:`, AppState.recipes)
    }
    async GetIngredientsByRecipeId(recipeId)
    {
        AppState.ingredientsForRecipe = []
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        const newIngredients = res.data.map((ingredients) => new Ingredient(ingredients))
        AppState.ingredientsForRecipe = newIngredients
        logger.log(AppState.ingredientsForRecipe)
        
    }
}

export const recipeService = new RecipeService()