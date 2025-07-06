namespace BlogStore.WebUI.Models
{
    public class AuthorDetailViewModel
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public List<ArticleSummaryViewModel> Articles { get; set; }
    }

    public class ArticleSummaryViewModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
