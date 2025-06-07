namespace Receptions.Data.Models
{
    using System.Collections.Generic;

    using Receptions.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
    }
}
