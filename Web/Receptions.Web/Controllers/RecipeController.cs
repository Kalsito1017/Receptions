namespace Receptions.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Receptions.Data.Common.Repositories;
    using Receptions.Data.Models;
    using Receptions.Services.Data;
    using Receptions.Web.ViewModels.Home.ASPViewModels;

    public class RecipeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IRecipeService recipeService;

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
