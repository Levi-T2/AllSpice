<template>
    <div class="modal fade" id="editRecipeModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Edit Recipe Instructions</h1>
                    <button @click="returnToDetails()" type="button" class="btn-close" data-bs-dismiss="modal"
                        aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="EditRecipe(activeRecipe.id)">
                        <div class="mb-3">
                            <label for="recipeInstructions" class="form-label">Instructions</label>
                            <textarea v-model="editable.instructions" type="text" class="form-control"
                                id="recipeInstructions" required maxlength=2200 />
                        </div>
                        <div class="my-1 text-end">
                            <button type="submit" class="btn btn-warning">Save Changes</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref } from 'vue';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
import { recipeService } from '../services/RecipeService';

export default {
    setup() {
        const editable = ref({})
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            editable,
            async EditRecipe(recipeId) {
                try {
                    const endpointUrl = `api/recipes/${recipeId}`
                    const editData = editable.value
                    await recipeService.EditRecipe(endpointUrl, editData)
                    Modal.getOrCreateInstance('#editRecipeModal').hide()
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


<style lang="scss" scoped>
.modal-header {
    background-color: rgb(36, 97, 36);
    color: white;
    border-bottom: 2px solid black;
}
</style>