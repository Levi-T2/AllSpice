<template>
  <header>
    <RecipeBanner />
  </header>
  <main>
    <router-view />
  </main>

  <!-- MODALS -->

  <AddRecipeModal />
  <RecipeDetailsModal />
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import RecipeBanner from './components/RecipeBanner.vue'
import RecipeDetailsModal from './components/RecipeDetailsModal.vue'
import AddRecipeBtn from './components/AddRecipeBtn.vue'
import AddRecipeModal from './components/AddRecipeModal.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { RecipeBanner, RecipeDetailsModal, AddRecipeBtn, AddRecipeModal },
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
