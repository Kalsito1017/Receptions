namespace Receptions.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Receptions.Web.ViewModels.Home.ASPViewModels;

    public class RecipeController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            // TODO: Reception is valid return to (page)
            return this.Redirect("/");
        }
    }
}
