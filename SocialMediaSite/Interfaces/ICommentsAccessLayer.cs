using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces
{
	public interface ICommentsAccessLayer 
	{
		public IEnumerable<Comments> GetComments();
		public IEnumerable<Comments> GetComments(int? pageID);
		public void AddComment(Comments comment);
	}
}
