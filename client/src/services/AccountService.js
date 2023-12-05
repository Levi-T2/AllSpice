import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Favorite } from '../models/Favorite'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async SetRecipesToFavorites()
  {
    const res = await api.get(`account/favorites`)
    const newRecipes = res.data.map((favorite) => new Favorite(favorite))
    AppState.recipes = newRecipes
  }
  async GetFavoritesForUser()
  {
      const res = await api.get(`account/favorites`)
      const newFavorites = res.data.map((favorite) => new Favorite(favorite))
      AppState.favorites = newFavorites
      logger.log(`[ACCOUNT SERVICE] favorites in our Appstate:`, AppState.favorites)
  }
}

export const accountService = new AccountService()
