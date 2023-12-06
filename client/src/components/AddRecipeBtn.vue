<template>
    <div class="container-fluid">
        <section class="row">
            <div class="col-12 d-flex justify-content-end mb-2">
                <button @click="OpenRecipeModal" class="btn btn-success rounded-circle text-light fw-bold fs-5">
                    <i class="mdi mdi-plus"></i>
                </button>
            </div>
        </section>
    </div>
</template>


<script>
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
export default {
    setup() {
        return {
            OpenRecipeModal() {
                try {
                    Modal.getOrCreateInstance('#addRecipeModal').show()
                } catch (error) {
                    Pop.error
                }
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