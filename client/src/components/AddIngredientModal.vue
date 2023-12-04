<template>
    <div class="modal fade" id="addIngredientModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Add Ingredient</h1>
                    <button @click="returnToDetails()" type="button" class="btn-close" data-bs-dismiss="modal"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="CreateIngredient(activeRecipe.id)">
                        <div class="mb-3">
                            <label for="ingredientName" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" class="form-control" id="ingredientName" required
                                maxlength=100>
                        </div>
                        <div class="mb-3">
                            <label for="ingredientQuantity" class="form-label">Quantity</label>
                            <input v-model="editable.quantity" type="text" class="form-control" id="ingredientQuantity"
                                required maxlength=100>
                        </div>
                        <div class="my-1 text-end">
                            <button type="submit" class="btn btn-success rounded-pill" title="">
                                Add
                                <i class="mdi mdi-plus-box-multiple"></i>
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { Modal } from 'bootstrap';
import { AppState } from '../AppState';
import { computed, ref } from 'vue';
import Pop from '../utils/Pop';
import { ingredientService } from '../services/IngredientService'

export default {
    setup() {
        const editable = ref({})
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            editable,
            async CreateIngredient(recipeId) {
                try {
                    const ingredientData = editable.value
                    ingredientData.recipeId = recipeId
                    await ingredientService.CreateIngredient(ingredientData)
                    Modal.getOrCreateInstance('#addIngredientModal').hide()
                    Modal.getOrCreateInstance('#recipeDetailsModal').show()
                } catch (error) {
                    Pop.error(error)
                }
            },
            returnToDetails() {
                Modal.getOrCreateInstance('#recipeDetailsModal').show()
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>