<template>
    <div id="recipeCard">
        <section class="row justify-content-center">
            <button v-if="!hasFavorited" @click="FavoriteRecipe(recipe.id)" class="btn btn-fav recipe-top"
                title="Favorite Recipe">
                <i class="mdi mdi-star-outline"></i>
            </button>
            <button v-else disabled class="btn btn-fav recipe-top" title="This recipe has been favorited">
                <i class="mdi mdi-star"></i>
            </button>
            <div role="button" @click="SetRecipeDetails(recipe)"
                class="col-12 recipe-card d-flex flex-column justify-content-between"
                :style="{ backgroundImage: `url(${recipe.img})` }"
                style="height: 20rem; width: 20rem; background-size: cover; background-position: center;">
                <div class="d-flex justify-content-between align-items-center">
                    <p class="recipe-top mb-0 mt-1 p-2">{{ recipe.category }}</p>
                </div>
                <div class="d-flex mb-1">
                    <p class="w-100 p-1 mb-0 text-center recipe-top">{{ recipe.title }}</p>
                </div>
            </div>
        </section>
    </div>
</template>


<script>
import { Modal } from 'bootstrap';
import { Recipe } from '../models/Recipe.js'
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
import { recipeService } from '../services/RecipeService';
import { computed, watch } from 'vue';
import { favoriteService } from '../services/FavoriteService';

export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup(props) {
        return {
            hasFavorited: computed(() => AppState.favorites.find((favorite) => favorite.recipeId == props.recipe.id)),
            async SetRecipeDetails(recipeData) {
                try {
                    AppState.activeRecipe = null
                    AppState.activeRecipe = recipeData
                    await recipeService.GetIngredientsByRecipeId(recipeData.id)
                    Modal.getOrCreateInstance('#recipeDetailsModal').show()
                } catch (error) {
                    Pop.error(error)
                }
            },
            async FavoriteRecipe(recipeId) {
                try {
                    await favoriteService.FavoriteRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                }
            }

        };
    },
};
</script>


<style lang="scss" scoped>
.recipe-img {
    height: 20rem;
    width: 20rem;
    object-fit: cover;
    background-position: center;
}

.recipe-card {
    border-radius: 6px;
    box-shadow: 1px 1px 7px 3px #666666;
    transition: ease-in-out 0.275s;
}

.recipe-card:hover {
    box-shadow: 1px 1px 9px 7px var(--bs-success);
}

.recipe-top {
    background-color: rgba(0, 0, 0, 0.288);
    border-radius: 5px;
    color: white;
    text-align: center;
    backdrop-filter: blur(10px);
}

.btn-fav {
    position: absolute;
    color: gold;
    border: 1.5px solid rgba(220, 220, 220, 0);
    transition: ease-in-out 0.275s;
    width: 5%;
    border-bottom-left-radius: 22px;
    margin-left: 16.25rem;
}

.btn-fav:hover {
    // transform: translateY(-0.35em);
    border: 1.5px solid gainsboro;
}
</style>