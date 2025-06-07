namespace Receptions.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Receptions.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Category.Any())
            {
                return;
            }

            await dbContext.Category.AddAsync(new Category { Name = "Пастърма" });
            await dbContext.Category.AddAsync(new Category { Name = "Мусака" });
            await dbContext.Category.AddAsync(new Category { Name = "Гръцка салата" });

            await dbContext.SaveChangesAsync();
        }
    }
}
