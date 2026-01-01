namespace Receptions.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Receptions.Web.ViewModels.Home.ASPViewModels;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel input, List<IFormFile> file);

        Task<List<RecipeCarouselViewModel>> GetHomeCarouselRecipesAsync();
    }
}
