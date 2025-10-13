namespace Receptions.Web.Controllers
{
    using System;
    using System.Collections.Generic;

    public class BlogPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }

        public string Excerpt { get; set; }

        public string Content { get; set; }
    }
}
