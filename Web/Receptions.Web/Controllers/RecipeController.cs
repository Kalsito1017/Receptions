namespace Receptions.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Receptions.Data;
    using Receptions.Data.Common.Repositories;
    using Receptions.Data.Models;
    using Receptions.Services.Data;
    using Receptions.Web.ViewModels.Home.ASPViewModels;

    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IRecipeService recipeService;
        private readonly ApplicationDbContext db;

        // public RecipeController(ApplicationDbContext db)
        // {
        //    this.db = db;
        // }

        // [HttpGet]
        // public IEnumerable<Recipe> Get()
        // {
        //    return this.db.Recipes.ToList();
        // }

        // [HttpPost]
        // public async Task<ActionResult> Post(Recipe recipe)
        // {
        //    await this.db.Recipes.AddAsync(recipe);
        //    await this.db.SaveChangesAsync();
        //    return this.CreatedAtAction("{GET}", new { Id = recipe.Id }, recipe);
        // }

        // test message
        public RecipeController(ICategoryService categoryService, IRecipeService recipeService)
        {
            this.categoryService = categoryService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            await this.recipeService.CreateAsync(inputModel);

            // TODO: Reception is valid return to (page)
            return this.Redirect("/");
        }
    }
}
