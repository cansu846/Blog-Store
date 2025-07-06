namespace BlogStore.WebUI.Models
{
    public class AuthorCardViewModel
    {
        public string UserName { get; set; } 
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int ArticleCount { get; set; }
    }
}
