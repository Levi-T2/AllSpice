<template>
    <div id="recipeCard">
        <section class="row justify-content-center">
            <div role="button" @click="setRecipeDetails(recipe)"
                class="col-12 recipe-card d-flex flex-column justify-content-between"
                :style="{ backgroundImage: `url(${recipe.img})` }"
                style="height: 20rem; width: 20rem; background-size: cover; background-position: center;">
                <div class="d-flex justify-content-between align-items-center">
                    <p class="recipe-top mb-0 mt-1 p-2">{{ recipe.category }}</p>
                    <button class="btn btn-fav recipe-top">
                        <i class="mdi mdi-star-plus-outline"></i>
                    </button>
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
import { logger } from '../utils/Logger';
import { AppState } from '../AppState';
import { recipeService } from '../services/RecipeService';
export default {
    props: {
        recipe: { type: Recipe, required: true }
    },
    setup() {
        return {
            async setRecipeDetails(recipeData) {
                try {
                    AppState.activeRecipe = {}
                    AppState.activeRecipe = recipeData
                    await recipeService.GetIngredientsByRecipeId(recipeData.id)
                    Modal.getOrCreateInstance('#recipeDetailsModal').show() // this line grabs a modal elem by its id and opens it...does the same this as bs-target&toggle
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
    border-radius: 10px;
    box-shadow: 1px 1px 7px 3px #666666;
    transition: ease-in-out 0.275s;
}

.recipe-card:hover {
    box-shadow: 1px 1px 7px 3px var(--bs-success);
}

.recipe-top {
    background-color: rgba(0, 0, 0, 0.288);
    border-radius: 8px;
    color: white;
    text-align: center;
    backdrop-filter: blur(10px);
}

.btn-fav {
    color: gold;
    border: 1.5px solid rgba(220, 220, 220, 0);
    transition: ease-in-out 0.275s;
}

.btn-fav:hover {
    transform: translateX(-0.35em);
    border: 1.5px solid gainsboro;
}
</style>