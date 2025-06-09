namespace Receptions.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using Receptions.Data.Common.Repositories;
    using Receptions.Data.Models;
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

        public IActionResult Index()
        {
            var viewmodel = new IndexViewModel
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                IngredientsCount = this.ingredientsRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
            };

            return this.View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
