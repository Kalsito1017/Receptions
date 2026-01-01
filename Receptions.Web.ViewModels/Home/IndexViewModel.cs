using System.ComponentModel.DataAnnotations;

using Receptions.Data.Models;
using Receptions.Web.ViewModels.Home;
using Receptions.Web.ViewModels.Home.Recipe;

public class IndexViewModel
{
    public int RecipesCount { get; set; }

    public int CategoriesCount { get; set; }

    public int IngredientsCount { get; set; }

    public int ImagesCount { get; set; }

    // Use only this list for the home page recipes
    public List<RecipeItem> Recipes { get; set; } = new();

    public List<RecipeImageViewModel> Images { get; set; } = new();

    public List<RecipeIngredient> RecipeIngredients { get; set; } = new();

    public List<Ingredient> Ingredients { get; set; } = new();

    public List<int> SelectedIngredientIds { get; set; } = new();

    public RecipeFilterInputModel Filters { get; set; }

    public int PageNumber { get; set; }

    public int TotalPages { get; set; }

    public string SearchQuery { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; }

    public IEnumerable<RecipeIngredientInputModel> RecipeIngredientInputModels { get; set; }

    // Nested class for each recipe in the home page
    public class RecipeItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public TimeSpan PrepTime { get; set; }

        public TimeSpan CookTime { get; set; }

        public int Servings { get; set; }

        // For display
        public List<string> Ingredients { get; set; } = new();

        // For filtering - store ingredient IDs as comma-separated string
        public string IngredientIds { get; set; }

        public List<RecipeImageViewModel> Images { get; set; } = new();
    }

    public class RecipeImageViewModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; } // Base64 or URL
    }
}
