<template>
    <div class="modal fade" id="recipeDetailsModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">
                <div v-if="activeRecipe" class="modal-body">
                    <div class="container-fluid">
                        <section class="row">
                            <div class="col-12 d-flex justify-content-end">
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="col-4">
                                <img :src="activeRecipe.img" alt="Recipe Image" class="recipe-img">
                            </div>
                            <div class="col-8">
                                <div class="px-2">
                                    <p class="fs-4 mb-0">{{ activeRecipe.title }}</p>
                                    <p class="mb-0 style-cat fw-bold">{{ activeRecipe.category }}</p>
                                </div>
                                <section class="row justify-content-around mt-3">
                                    <div class="col-6">
                                        <p class="mb-0 fs-4 text-center recipe-title">Instructions</p>
                                        <div class="recipe-table">
                                            <p class="mb-0 p-2">{{ activeRecipe.instructions }}</p>
                                        </div>
                                        <div role="button" class="recipe-btn" title="Edit Recipe Instructions"
                                            data-bs-toggle="modal" data-bs-target="#editRecipeModal">
                                            <p class="mb-0 recipe-txt">
                                                Edit
                                                <i class="mdi mdi-pen-plus"></i>
                                            </p>
                                        </div>
                                    </div>
                                    <div v-if="ingredients" class="col-6">
                                        <p class="mb-0 fs-4 text-center recipe-title">Ingredients</p>
                                        <div v-for="ingredient in ingredients" :key="ingredient.id" class="recipe-table">
                                            <p class="mb-0 p-2">
                                                <span>{{ ingredient.quantity }}</span>
                                                {{ ingredient.name }}
                                            </p>
                                        </div>
                                        <div role="button" class="recipe-btn" title="Add Ingredient..."
                                            data-bs-toggle="modal" data-bs-target="#addIngredientModal">
                                            <p class="mb-0 recipe-txt">
                                                Add
                                                <i class="mdi mdi-plus-circle"></i>
                                            </p>
                                        </div>
                                    </div>
                                </section>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modals -->
    <EditRecipeModal />
    <AddIngredientModal />
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js'
import EditRecipeModal from './EditRecipeModal.vue';
import AddIngredientModal from './AddIngredientModal.vue';

export default {
    setup() {
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredientsForRecipe)
        };
    },
    components: { EditRecipeModal, AddIngredientModal }
};
</script>


<style lang="scss" scoped>
.style-cat {
    background-color: grey;
    border-radius: 10px;
    width: 18%;
    text-align: center;
    color: white;
}

.recipe-img {
    max-height: 27.5rem;
    width: 20rem;
    background-size: cover;
    background-position: center;
}

.recipe-title {
    background-color: rgb(36, 97, 36);
    color: white;
    border-top-left-radius: 6px;
    border-top-right-radius: 6px;
}

.recipe-table {
    background-color: gainsboro;
    border-left: 1px solid black;
    border-right: 1px solid black;
    border-bottom: 1px solid black;
}

.recipe-btn {
    background-color: var(--bs-success);
    border-bottom-left-radius: 6px;
    border-bottom-right-radius: 6px;
    color: white;
    text-align: center;
    transition: ease-in-out 0.275s;
}

.recipe-btn:hover {
    background-color: rgb(36, 97, 36);
    color: white;
}

.recipe-txt {
    color: black;
    transition: ease-in-out 0.275s;
    padding: 0.185rem;
}

.recipe-txt:hover {
    color: white;
}
</style>