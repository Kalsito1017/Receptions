namespace Receptions.Web.ViewModels.Home.ASPViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.AspNetCore.Http;
    using Receptions.Data.Models;
    using Receptions.Web.ViewModels.Home.Recipe;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(4)]
        [DisplayName("Име на рецепта")]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [DisplayName("Инструкции")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Моля въведете време за приготвяне")]
        [Display(Name = "Време за приготвяне (минути)")]
        [DataType(DataType.Duration)]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Моля въведете време за готвене")]
        [Display(Name = "Време за готвене (минути)")]
        [DataType(DataType.Duration)]
        public int TimeSpan { get; set; }

        [Required(ErrorMessage = "Моля въведете брой порции")]
        [Display(Name = "Брой порции")]
        public int PortionsCount { get; set; }

        [DisplayName("Катерогия")]

        public int CategoryId { get; set; }

        [AllowNull]
        [DisplayName("Съставки")]

        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public List<IFormFile> UploadedImages { get; set; }
    }
}
