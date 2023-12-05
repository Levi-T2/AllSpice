import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoriteService 
{
    async FavoriteRecipe(recipeId)
    {
        const favData = { recipeId: recipeId }
        const res = await api.post(`api/favorites`, favData)
        logger.log('[FAVORITED RECIPE]: ', res.data)
    }
}

export const favoriteService = new FavoriteService()