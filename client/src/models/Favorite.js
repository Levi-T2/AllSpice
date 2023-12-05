
export class Favorite
{ constructor(data)
    {
        this.recipeId = data.id
        this.favoriteId = data.favoriteId
        this.accountId = data.accountId
        this.title = data.title
        this.instructions = data.instructions
        this.category = data.category
        this.img = data.img
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}
