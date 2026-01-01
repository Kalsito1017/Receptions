namespace Receptions.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecipeListViewModel
    {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Author { get; set; }

            public string ImageUrl { get; set; }

            public double Rating { get; set; }

            public int VotesCount { get; set; }

            public DateTime CreatedOn { get; set; }

            public List<string> ImageUrls { get; set; } = new();
    }
}
