namespace Receptions.Services.Data;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Receptions.Data.Common.Repositories;
    using Receptions.Data.Models;
    using Receptions.Web.ViewModels.Home.ASPViewModels;

    public class RecipeService : IRecipeService
    {
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;

        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public RecipeService(
            IDeletableEntityRepository<Recipe> recipeRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input)
    {
        var recipe = new Recipe()
        {
            CategoryId = input.CategoryId,
            TimeSpan = TimeSpan.FromMinutes(input.TimeSpan),
            Instructions = input.Instructions,
            Name = input.Name,
            PortionsCount = input.PortionsCount,
            PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
        };
        foreach (var inputIngredient in input.Ingredients)
        {
           var ingredient = this.ingredientRepository.All().FirstOrDefault(x => x.Name == inputIngredient.IngredientName);
           if (ingredient == null)
            {
                ingredient = new Ingredient { Name = inputIngredient.IngredientName };
            }

           recipe.Ingredients.Add(new RecipeIngredient
            {
                Ingredient = ingredient,
                Quantity = inputIngredient.Quantity,
            });
        }

        await this.recipeRepository.AddAsync(recipe);
        await this.recipeRepository.SaveChangesAsync();
    }
}
