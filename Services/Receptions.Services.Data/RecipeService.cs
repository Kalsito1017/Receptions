namespace Receptions.Services.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Receptions.Data.Common.Repositories;
using Receptions.Data.Models;
using Receptions.Web.ViewModels.Home.ASPViewModels;
using Receptions.Web.ViewModels.Home.Recipes;

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

        public async Task<List<RecipeCarouselViewModel>> GetHomeCarouselRecipesAsync()
    {
        return await this.recipeRepository.All()
            .Include(r => r.Images) // load related images
            .OrderByDescending(r => r.CreatedOn)
            .Select(r => new RecipeCarouselViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Instructions = r.Instructions,
                Images = r.Images.Select(i => new RecipeCarouselViewModel.ImageViewModel
                {
                    Name = i.Name,
                    ImageUrl = "data:" + i.ContentType + ";base64," + Convert.ToBase64String(i.Data),
                }).ToList(),
            })
            .ToListAsync();
    }

        public async Task CreateAsync(CreateRecipeInputModel input, List<IFormFile> uploadedImages)
    {
        var recipe = new Recipe()
        {
            CategoryId = input.CategoryId,
            TimeSpan = TimeSpan.FromMinutes(input.TimeSpan),
            Instructions = input.Instructions,
            Name = input.Name,
            PortionsCount = input.PortionsCount,
            PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
            Images = new List<Image>(),
        };

        foreach (var inputIngredient in input.Ingredients)
        {
            var ingredient = this.ingredientRepository.All()
                .FirstOrDefault(x => x.Name == inputIngredient.IngredientName);

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

        // images (max 5)
        if (uploadedImages != null && uploadedImages.Any())
        {
            foreach (var file in uploadedImages.Take(5))
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    recipe.Images.Add(new Image
                    {
                        Name = Path.GetFileName(file.FileName),
                        Data = ms.ToArray(),
                        ContentType = file.ContentType,
                        Extension = Path.GetExtension(file.FileName),
                    });
                }
            }
        }

        await this.recipeRepository.AddAsync(recipe);
        await this.recipeRepository.SaveChangesAsync();
    }
}
