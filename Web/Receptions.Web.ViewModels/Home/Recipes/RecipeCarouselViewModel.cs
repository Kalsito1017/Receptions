public class RecipeCarouselViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Instructions { get; set; }

    public List<ImageViewModel> Images { get; set; } = new();

    public class ImageViewModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; } // base64 or URL
    }
}
