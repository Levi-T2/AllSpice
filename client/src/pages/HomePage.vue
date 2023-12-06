<template>
  <div class="container-fluid">
    <section v-if="recipes.length" class="row d-custom">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4 my-2">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
    <section v-else class="row flex-column align-items-center justify-content-center">
      <div class="col-12 text-center">
        <p class="mt-2 mb-0 fs-2 text-center">
          <i class="mdi mdi-autorenew mdi-spin"></i>
          Loading...
        </p>
      </div>
    </section>
  </div>
  <div class="sticky-bottom">
    <AddRecipeBtn />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipeService } from '../services/RecipeService';
import { AppState } from '../AppState.js'
import RecipeCard from '../components/RecipeCard.vue'
import RecipeDetailsModal from '../components/RecipeDetailsModal.vue';
import { favoriteService } from '../services/FavoriteService';
import { accountService } from '../services/AccountService';
import AddRecipeBtn from '../components/AddRecipeBtn.vue';

export default {
  setup() {
    onMounted(() => {
      GetRecipes();
      GetFavoritesForUser();
    })
    async function GetRecipes() {
      try {
        await recipeService.GetRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }
    async function GetFavoritesForUser() {
      try {
        await accountService.GetFavoritesForUser()
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      recipes: computed(() => AppState.recipes),
    }
  },
  components: { RecipeCard, RecipeDetailsModal, AddRecipeBtn },
}
</script>

<style scoped lang="scss">
.d-custom {
  justify-content: space-around;
}

@media (max-width: 768px) {
  .d-custom {
    justify-content: center;
    align-items: center;
  }
}
</style>
