import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipeService {
    async GetRecipes() {
        const res = await api.get("api/recipes")
        const newRecipes = res.data.map((recipes) => new Recipe(recipes))
        AppState.recipes = newRecipes
        logger.log(`[RECIPE SERVICE] These are the recipes in the AppState:`, AppState.recipes)
    }
    async GetRecipesWithQuery(endpointUrl) {
        const res = await api.get(endpointUrl)
        const newRecipes = res.data.map((recipe) => new Recipe(recipe))
        AppState.recipes = newRecipes
    }
    async GetIngredientsByRecipeId(recipeId) {
        AppState.ingredientsForRecipe = []
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        const newIngredients = res.data.map((ingredients) => new Ingredient(ingredients))
        AppState.ingredientsForRecipe = newIngredients
        logger.log(AppState.ingredientsForRecipe)
    }
    async AddRecipe(recipeData) {
        const res = await api.post(`api/recipes`, recipeData)
        const newRecipe = new Recipe(res.data)
        AppState.recipes.push(newRecipe)
    }
    async EditRecipe(recipeId, editData) {
        let recipeIndex = AppState.recipes.findIndex((recipe) => recipe.id == recipeId)
        const res = await api.put(`api/recipes/${recipeId}`, editData)
        const editedRecipe = new Recipe(res.data)
        AppState.activeRecipe = editedRecipe
        AppState.recipes.splice(recipeIndex, 1, editedRecipe)
    }
    async DeleteRecipe(recipeId) {
        const recipeIndex = AppState.recipes.findIndex((recipe) => recipe.id == recipeId)
        const res = await api.delete(`api/recipes/${recipeId}`)
        AppState.recipes.splice(recipeIndex, 1)
    }

}

export const recipeService = new RecipeService()