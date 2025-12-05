namespace Receptions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Receptions.Data.Common.Repositories;
    using Receptions.Data.Models;

    public class BlogController : Controller
    {
        private readonly IDeletableEntityRepository<BlogPost> blogRepository;

        public BlogController(IDeletableEntityRepository<BlogPost> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public IActionResult Index()
        {
            var articles = this.blogRepository.All()
                .OrderByDescending(x => x.PublishedOn)
                .Select(x => new BlogPostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Date = x.PublishedOn,
                    ImageUrl = x.ImageUrl,
                    Excerpt = x.Excerpt,
                })
                .ToList();

            return this.View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = this.blogRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new BlogPostViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    Date = x.PublishedOn,
                    ImageUrl = x.ImageUrl,
                    Content = x.Content,
                })
                .FirstOrDefault();

            if (article == null)
            {
                return this.NotFound();
            }

            return this.View(article);
        }
    }
}
