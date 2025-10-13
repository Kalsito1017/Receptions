namespace Receptions.Web.ViewModels.Home
{
    using Receptions.Data.Models;

    public class IndexViewModel
    {
        public int RecipesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int IngredientsCount { get; set; }

        public int ImagesCount { get; set; }

        public IEnumerable<RecipeListViewModel> Recipes { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public string SearchQuery { get; set; }
    }
}
