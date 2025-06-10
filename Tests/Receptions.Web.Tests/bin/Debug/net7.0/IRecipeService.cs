namespace Receptions.Services.Data
{
    using System.Threading.Tasks;

    using Receptions.Web.ViewModels.Home.ASPViewModels;

    public interface IRecipeService
    {
        Task CreateAsync(CreateRecipeInputModel input);
    }
}
