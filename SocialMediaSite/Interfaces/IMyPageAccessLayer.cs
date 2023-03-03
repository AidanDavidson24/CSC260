using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces
{
    public interface IMyPageAccessLayer
    {
        public void CreatePage(MyPage page);
        public MyPage GetMyPage(string userID);
        public MyPage GetMyPage(int? pageID);
        public void EditAboutMe(string userID, string message);
        public void ChangePhoto(string userID, int? imageID);
        public IEnumerable<MyPage> Search(string key);
    }
}
