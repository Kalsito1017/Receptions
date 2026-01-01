using System;

using Receptions.Data.Common.Models;

public class BlogPost : BaseDeletableModel<int>
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Content { get; set; }

    public string ImageUrl { get; set; }

    public string Excerpt { get; set; }

    public DateTime PublishedOn { get; set; }
}
