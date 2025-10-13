namespace Receptions.Web.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var articles = new List<BlogPostViewModel>
            {
                new BlogPostViewModel
                {
                    Id = 1,
                    Title = "Тайната на перфектната шкембе чорба",
                    Date = DateTime.Now.AddDays(-2),
                    Author = "Калоян Стоичков",
                    ImageUrl = "/images/shkembe.jpg",
                    Excerpt = "Шкембе чорбата е класика в българската кухня. Научи тайната на добрия вкус...",
                    Content = "...",
                },
                new BlogPostViewModel
                {
                    Id = 2,
                    Title = "Как се приготвя традиционна баница",
                    Date = DateTime.Now.AddDays(-5),
                    Author = "Мария Петрова",
                    ImageUrl = "/images/banitsa.jpg",
                    Excerpt = "Истинската българска баница изисква внимание и любов към детайла...",
                    Content = "...",
                },
            };

            return this.View(articles);
        }

        public IActionResult Details(int id)
        {
            // Normally you'd fetch the post from a database; here’s dummy data:
            var article = new BlogPostViewModel
            {
                Id = id,
                Title = "Тайната на перфектната шкембе чорба",
                Date = DateTime.Now.AddDays(-2),
                Author = "Калоян Стоичков",
                ImageUrl = "/images/shkembe.jpg",
                Content = @"
                    <p>Шкембе чорбата е едно от най-емблематичните ястия на българската кухня...</p>
                    <p>Истинският вкус идва от правилно подготвеното шкембе и ароматния чеснов сос.</p>
                ",
            };

            return this.View(article);
        }
    }
}
