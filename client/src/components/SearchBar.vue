<template>
    <form @submit.prevent="QueryRecipes()" class="d-flex">
        <div class="search-container d-flex">
            <input v-model="search" class="search-box" type="search" name="searchBox" placeholder="Search...">
            <p class="mb-0">|</p>
            <button type="submit" class="search-btn" title="Search">
                <i class="mdi mdi-magnify"></i>
            </button>
        </div>
    </form>
</template>


<script>
import { ref } from 'vue';
import { recipeService } from '../services/RecipeService';

export default {
    setup() {
        const search = ref("")
        return {
            search,
            async QueryRecipes() {
                try {
                    const category = search.value
                    const endpointUrl = `api/recipes?category=${category}`
                    await recipeService.GetRecipesWithQuery(endpointUrl)
                    logger.log(category)
                } catch (error) {
                    Pop.error(error)
                }
            },
        }
    }
};
</script>


<style lang="scss" scoped>
.search-container {
    background-color: white;
    padding: 0.25rem;
    border-radius: 17px;
}

.search-box {
    border-bottom-left-radius: 6px;
    border-top-left-radius: 6px;
    border: 1px solid rgba(0, 0, 0, 0);
}

.search-btn {
    background-color: white;
    padding-left: 0.65rem;
    padding-right: 0.65rem;
    border-radius: 20px;
    transition: ease-in-out 0.275s;
    border: 1px solid rgba(0, 0, 0, 0)
}

.search-btn:hover {
    background-color: gainsboro;
}
</style>