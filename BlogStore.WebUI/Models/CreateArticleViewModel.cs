using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogStore.WebUI.Models
{
    public class CreateArticleViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public string Slug { get; set; }
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; } = new(); // dropdown için
    }
}
