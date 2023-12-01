<template>
    <div class="modal fade" id="recipeDetailsModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg">
            <div class="modal-content">
                <div v-if="activeRecipe" class="modal-body">
                    <div class="container-fluid">
                        <section class="row">
                            <div class="col-12 d-flex justify-content-end">
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="col-4">
                                <img :src="activeRecipe.img" alt="Recipe Image" class="img-fluid">
                            </div>
                            <div class="col-8">
                                <p class="fs-4 mb-0">{{ activeRecipe.title }}</p>
                                <p class="mb-0 style-cat fw-bold">{{ activeRecipe.category }}</p>
                                <section class="row justify-content-around mt-3">
                                    <div class="col-5">
                                        <p>{{ activeRecipe.instructions }}</p>
                                    </div>
                                    <div v-if="ingredients" class="col-6">
                                        <p class="mb-0 fs-4 text-center">Ingredients</p>
                                        <div v-for="ingredient in ingredients" :key="ingredient.id">
                                            <p>
                                                <span>{{ ingredient.quantity }}</span>
                                                {{ ingredient.name }}
                                            </p>
                                        </div>
                                        <div class="text-center">
                                            <button class="btn btn-success">Add Ingredient
                                                <i class="mdi mdi-plus"></i>
                                            </button>
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
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js'

export default {
    setup() {
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            ingredients: computed(() => AppState.ingredientsForRecipe)
        }
    }
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
</style>