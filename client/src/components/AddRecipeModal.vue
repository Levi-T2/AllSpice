<template>
    <div class="modal fade" id="addRecipeModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Add Recipe</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="AddRecipe()">
                        <section class="row g-3">
                            <div class="col mb-3">
                                <label for="recipeTitle" class="form-label">Title</label>
                                <input v-model="editable.title" type="text" class="form-control" id="recipeTitle" required
                                    maxlength=100>
                            </div>
                            <div class="col mb-3">
                                <label for="recipeCategory" class="form-label">Category</label>
                                <input v-model="editable.category" type="text" class="form-control" id="recipeCategory"
                                    required maxlength=250>
                            </div>
                        </section>
                        <div class="mb-3">
                            <label for="recipeInstructions" class="form-label">Instructions</label>
                            <textarea v-model="editable.instructions" type="text" class="form-control"
                                id="recipeInstructions" required maxlength=2200 />
                        </div>
                        <div class="mb-3">
                            <label for="recipeImg" class="form-label">Image Link</label>
                            <input v-model="editable.img" type="url" class="form-control" id="recipeImg"
                                aria-describedby="imgHelp" required maxlength=1500>
                            <div id="imgHelp" class="form-text text-center"> This must be a link! </div>
                        </div>
                        <div class="my-1 text-end">
                            <button type="submit" class="btn btn-success rounded-pill text-light" title="Submit Recipe">
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
import { ref } from 'vue';
import { recipeService } from '../services/RecipeService';
import { Modal } from 'bootstrap';
export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async AddRecipe() {
                const recipeData = editable.value
                await recipeService.AddRecipe(recipeData)
                editable.value = {}
                Modal.getOrCreateInstance('#addRecipeModal').hide()
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