namespace Receptions.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Context { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
