namespace Receptions.Web.ViewModels.Home.Recipes
{
    public class RecipeDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan TimeSpan { get; set; } // Cooking time

        public int PortionsCount { get; set; }

        public string CategoryName { get; set; }

        public List<ImageViewModel> Images { get; set; } = new();

        public List<RecipeIngredientViewModel> Ingredients { get; set; } = new();

        public List<CommentInputModel> Comments { get; set; } = new();

        public double AverageRating { get; set; } // Average of all ratings

        public int UserRating { get; set; } // The logged-in user's rating, if any
    }

    public class ImageViewModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; } // base64 or URL
    }

    public class RecipeIngredientViewModel
    {
        public string Name { get; set; }

        public string Quantity { get; set; }
    }
    public class CommentInputModel
    {
        public int RecipeId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
