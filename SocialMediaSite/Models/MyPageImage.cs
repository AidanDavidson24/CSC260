using Microsoft.AspNetCore.Mvc.Rendering;

namespace SocialMediaSite.Models
{
    public class MyPageImage
    {
        public MyPage myPages { get; set; }
        public SelectList Images { get; set; }
        public IEnumerable<CommentStuff> Comments { get; set; }

        public MyPageImage() { }

        public MyPageImage(MyPage myPages, SelectList Images) 
        { 
            this.myPages = myPages;
            this.Images = Images;
        }

		public MyPageImage(MyPage myPages, IEnumerable<CommentStuff> comments)
		{
			this.myPages = myPages;
            this.Comments = comments;
		}
	}
}
