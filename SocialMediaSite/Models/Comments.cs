using System.ComponentModel.DataAnnotations;

namespace SocialMediaSite.Models
{
	public class Comments
	{
		[Key]
		[Required]
		public int Id { get; set; }
		public string? userID { get; set; }
		public string? userName { get; set; }
		public int? pageID { get; set; }
		public string? message { get; set; }

		public Comments() { }

		public Comments(int pageID, string userID, string message)
		{ 
			this.pageID = pageID;
			this.userID = userID;
			this.message = message;
		}
	}
}
