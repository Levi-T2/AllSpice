import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { api } from "./AxiosService"

class IngredientService
{
    async CreateIngredient(ingredientData) {
        const res = await api.post(`api/ingredients`, ingredientData)
        const newIngredient = new Ingredient(res.data)
        AppState.ingredientsForRecipe.push(newIngredient)
    }
}

export const ingredientService = new IngredientService()