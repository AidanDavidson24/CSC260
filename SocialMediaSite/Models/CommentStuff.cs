namespace SocialMediaSite.Models
{
	public class CommentStuff
	{
		public Comments comment { get; set; }
		public string userName { get; set; }
		public string userPageID { get; set; }

		public CommentStuff() { }

		public CommentStuff(Comments comment, string userName, string userPageID)
		{
			this.comment = comment;
			this.userName = userName;
			this.userPageID = userPageID;
		}
	}
}
