using System;

public class Comment
{
    public int Id { get; set; } // Primary key

    public int RecipeId { get; set; } // Foreign key to the recipe

    public string UserName { get; set; } // User who wrote it

    public string Text { get; set; } // The comment text

    public DateTime CreatedAt { get; set; } // Timestamp
}
