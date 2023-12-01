<template>
    <div class="container-fluid">
        <section class="row">
            <div class="col-12 d-flex mb-4">
                <button @click="openRecipeModal" class="btn btn-success rounded-circle text-light fw-bold">
                    <i class="mdi mdi-plus"></i>
                </button>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';
export default {
    setup() {
        return {
            openRecipeModal() {
                try {
                    Modal.getOrCreateInstance('#exampleModal').show()
                } catch (error) {
                    Pop.error
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>