using System.ComponentModel.DataAnnotations;

using Receptions.Data.Models;

public class RecipeRating
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; }

    public string UserId { get; set; }

    public virtual ApplicationUser User { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; } // 1 to 5 stars
}
