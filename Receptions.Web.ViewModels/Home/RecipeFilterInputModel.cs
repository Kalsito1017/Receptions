namespace Receptions.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    public class RecipeFilterInputModel
    {
        public string Category { get; set; }

        public int? Servings { get; set; }

        [FromQuery(Name = "IngredientIds")]
        public List<int> IngredientIds { get; set; } = new List<int>();
    }
}
