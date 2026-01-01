namespace Receptions.Data.Models
{
    using System;

    using Receptions.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        // File extension (.jpg, .png)
        public string Extension { get; set; }

        // 📌 The actual image data stored in the DB
        public byte[] Data { get; set; }

        // 📌 Example: "image/png", "image/jpeg"
        public string ContentType { get; set; }
    }
}
