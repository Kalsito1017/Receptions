﻿namespace Receptions.Data.Models
{
    using System;

    using Receptions.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        // Image Test Message
        public Image()
        {
               this.Id = Guid.NewGuid().ToString();
        }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string Extension { get; set; }
    }
}
