namespace BlogStore.WebUI.Models
{
    public class UpdateProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
