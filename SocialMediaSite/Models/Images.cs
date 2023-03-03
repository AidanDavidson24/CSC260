using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
    public class Images
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? userID { get; set; }
        [Required(ErrorMessage = "You must have an image link.")]
        public string imageName { get; set; }

        public Images() { }
        public Images(string userID, string imageName) 
        {
            this.userID = userID;
            this.imageName = imageName;
        }
    }
}
