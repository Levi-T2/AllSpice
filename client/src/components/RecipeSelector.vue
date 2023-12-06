<template>
    <div class="selector">
        <p @click="DisplayAll()" role="button" class="selector-1">Home</p>
        <p class="mb-0">|</p>
        <p @click="DisplayMyRecipes()" role="button" class="selector-2">My Recipes</p>
        <p class="mb-0">|</p>
        <p @click="DisplayFavorites()" role="button" class="selector-3">Favorites</p>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { recipeService } from '../services/RecipeService';
import { accountService } from '../services/AccountService';

export default {
    setup() {
        return {
            async DisplayAll() {
                try {
                    AppState.recipes = []
                    await recipeService.GetRecipes()
                } catch (error) {
                    Pop.error(error)
                }
            },
            async DisplayMyRecipes() {
                try {
                    AppState.recipes = []
                    await accountService.SetRecipesToMyRecipes()
                    if (AppState.recipes.length == 0) {
                        Pop.toast("You haven't made any recipes")
                    }
                } catch (error) {
                    Pop.error(error)
                }
            },
            async DisplayFavorites() {
                try {
                    AppState.recipes = []
                    await accountService.SetRecipesToFavorites()
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped>
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
    padding-left: 0.7rem;
    padding-right: 0.7rem;
    transition: ease-in-out 0.225s;
}

.selector-1:hover {
    transform: translateY(-0.275rem);
    color: var(--bs-success);
}

.selector-2 {
    margin-bottom: 0%;
    padding-left: 0.7rem;
    padding-right: 0.7rem;
    transition: ease-in-out 0.225s;

}

.selector-2:hover {
    transform: translateY(-0.275rem);
    color: var(--bs-success);
}

.selector-3 {
    margin-bottom: 0%;
    padding-left: 0.7rem;
    padding-right: 0.7rem;
    transition: ease-in-out 0.225s;
}

.selector-3:hover {
    transform: translateY(-0.275rem);
    color: var(--bs-success);
}
</style>