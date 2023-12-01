<template>
    <div class="container-fluid">
        <section class="row">
            <div class="col-12 my-1 mb-5">
                <div class="banner">
                    <img class="banner-img"
                        src="https://images.unsplash.com/photo-1690983323310-3f8e55c9272f?w=900&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGNvb2tpbmclMjBiYW5uZXJ8ZW58MHx8MHx8fDA%3D">
                    <div class="banner-center text-light">
                        <p class="mb-0 txt-shadow fs-2">All-Spice</p>
                        <p class="mb-0 txt-shadow">Cherish Your Family and Their Cooking</p>
                    </div>
                    <div class="banner-center-bottom">
                        <div class="selector">
                            <p role="button" class="selector-1">Home</p>
                            <p role="button" class="selector-2">My Recipes</p>
                            <p role="button" class="selector-3">Favorites</p>
                        </div>
                    </div>
                    <div class="banner-top-right">
                        <Login />
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Login from './Login.vue';
export default {
    setup() {
        return {};
    },
    components: { Login }
};
</script>


<style lang="scss" scoped>
.txt-shadow {
    text-shadow: 2px 4.5px 4px black;
    color: white;
}

.banner-img {
    height: 24rem;
    width: 100%;
    background-size: cover;
    background-position: center;
    border-radius: 6px;
    box-shadow: 1px 1px 7px 3px #666666;
}

// SECTION Selector CSS

.selector {
    box-shadow: 1px 1px 7px 3px #666666;
    display: flex;
    justify-content: center;
    background-color: aliceblue;
    border-radius: 4px;
    padding: 0.8rem;
}

.selector-1 {
    margin-bottom: 0%;
    padding-left: 0.6rem;
    padding-right: 0.6rem;
    transition: ease-in-out 0.225s;
}

.selector-1:hover {
    transform: translateY(-0.25rem);
}

.selector-2 {
    margin-bottom: 0%;
    padding-left: 0.6rem;
    padding-right: 0.6rem;
    transition: ease-in-out 0.225s;

}

.selector-2:hover {
    transform: translateY(-0.25rem);
}

.selector-3 {
    margin-bottom: 0%;
    padding-left: 0.6rem;
    padding-right: 0.6rem;
    transition: ease-in-out 0.225s;
}

.selector-3:hover {
    transform: translateY(-0.25rem);
}

// !SECTION


// SECTION This CSS effects our banner and is how we overlay text onto it.

.banner {
    position: relative;
    text-align: center;
}

.banner-center {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}

.banner-center-bottom {
    position: absolute;
    top: 100%;
    left: 50%;
    transform: translate(-50%, -50%);

}

.banner-top-right {
    position: absolute;
    top: 8px;
    right: 16px;
}

// !SECTION
</style>