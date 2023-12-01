<template>
  <div class="container-fluid">
    <section class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4">
        {{ recipe.title }}
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipeService } from '../services/RecipeService';
import { AppState } from '../AppState.js'

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
  }
}
</script>

<style scoped lang="scss"></style>
