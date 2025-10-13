namespace Receptions.Web.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            var article = new ArticleViewModel
            {
                Title = "Тайната на перфектната шкембе чорба",
                Author = "Калоян Стоичков",
                Date = DateTime.Now,
                ImageUrl = "/images/shkembe.jpg",
                Content = @"
<p>Шкембе чорбата е едно от най-емблематичните ястия на българската кухня. 
Тя има богата история и се приготвя по различни начини в различните краища на страната.</p>

<p>Основната тайна на вкусната шкембе чорба е в правилното почистване и варене на шкембето, 
както и в добре балансираната смес от чесън, оцет и люто. 
Много готвачи препоръчват да се остави чорбата да престои поне 24 часа, за да се смесят ароматите напълно.</p>

<p>Не забравяйте да сервирате чорбата с препечен хляб и студена ракия – класическата комбинация за зимните дни!</p>
",
            };

            return this.View(article);
        }
    }
}
