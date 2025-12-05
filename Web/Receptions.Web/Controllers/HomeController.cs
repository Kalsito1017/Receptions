using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Receptions.Data.Common.Repositories;
using Receptions.Data.Models;
using Receptions.Web.Controllers;
using Receptions.Web.ViewModels;
using Receptions.Web.ViewModels.Home;

public class HomeController : BaseController
{
    private readonly IDeletableEntityRepository<Category> categoriesRepository;
    private readonly IRepository<Image> imagesRepository;
    private readonly IDeletableEntityRepository<Recipe> recipesRepository;
    private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

    public HomeController(
        IDeletableEntityRepository<Category> categoriesRepository,
        IRepository<Image> imagesRepository,
        IDeletableEntityRepository<Recipe> recipesRepository,
        IDeletableEntityRepository<Ingredient> ingredientsRepository)
    {
        this.categoriesRepository = categoriesRepository;
        this.imagesRepository = imagesRepository;
        this.recipesRepository = recipesRepository;
        this.ingredientsRepository = ingredientsRepository;
    }

    public IActionResult Index(string search = "", int page = 1)
    {
        const int pageSize = 12; // Recipes per page

        // Get recipes with search filter
        var recipesQuery = this.recipesRepository.All().AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            recipesQuery = recipesQuery.Where(r =>
                r.Name.Contains(search) || // Changed from Title to Name
                r.Instructions.Contains(search) || // Search in instructions
                r.Ingredients.Any(ri => ri.Ingredient.Name.Contains(search))); // Fixed navigation property
        }

        var totalRecipes = recipesQuery.Count();
        var totalPages = (int)Math.Ceiling(totalRecipes / (double)pageSize);

        // Ensure page is within valid range
        page = Math.Max(1, Math.Min(page, totalPages == 0 ? 1 : totalPages));

        var recipes = recipesQuery
            .OrderByDescending(r => r.CreatedOn)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r => new RecipeListViewModel
            {
                Id = r.Id,
                Title = r.Name, // Map Recipe.Name to ViewModel.Title
                Author = r.User.UserName, // Changed from Author to User
                ImageUrl = r.Images.FirstOrDefault().Id != null ?
                          $"/images/{r.Images.FirstOrDefault().Id}{r.Images.FirstOrDefault().Extension}"
                          : "/images/default-recipe.jpg",
                Rating = 0, // Your Recipe model doesn't have Ratings - set default or remove
                VotesCount = 0, // Your Recipe model doesn't have Ratings
                CreatedOn = r.CreatedOn,
            })
            .ToList();

        // Get categories with recipe counts
        var categories = this.categoriesRepository.All()
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                RecipeCount = c.Recipes.Count(r => !r.IsDeleted),
            })
            .OrderByDescending(c => c.RecipeCount)
            .Take(10) // Top 10 categories
            .ToList();

        var viewModel = new IndexViewModel
        {
            RecipesCount = totalRecipes,
            IngredientsCount = this.ingredientsRepository.All().Count(),
            CategoriesCount = this.categoriesRepository.All().Count(),
            ImagesCount = this.imagesRepository.All().Count(),
            Recipes = recipes,
            Categories = categories,
            PageNumber = page,
            TotalPages = totalPages,
            SearchQuery = search,
        };

        return this.View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
