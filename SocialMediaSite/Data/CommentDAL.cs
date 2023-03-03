using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data
{
	public class CommentDAL : ICommentsAccessLayer
	{
		private ApplicationDbContext db;

		public CommentDAL(ApplicationDbContext indb)
		{
			db = indb;
        }

		public void AddComment(Comments comment)
		{
			db.Add(comment);
			db.SaveChanges();
		}

		public IEnumerable<Comments> GetComments()
		{
			return db.Comments;
		}

		public IEnumerable<Comments> GetComments(int? pageID)
		{
			return db.Comments.Where(x => x.pageID == pageID);
		}
	}
}
