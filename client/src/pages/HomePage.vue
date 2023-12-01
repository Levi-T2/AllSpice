<template>
  <div class="container-fluid">
    <section class="row d-custom">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4 my-2">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipeService } from '../services/RecipeService';
import { AppState } from '../AppState.js'
import RecipeCard from '../components/RecipeCard.vue'

export default {
  setup() {
    onMounted(() => {
      GetRecipes();
    })
    async function GetRecipes() {
      try {
        await recipeService.GetRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      recipes: computed(() => AppState.recipes),
    }
  },
  components: { RecipeCard },
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
