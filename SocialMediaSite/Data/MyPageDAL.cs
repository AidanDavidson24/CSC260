using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data
{
    public class MyPageDAL : IMyPageAccessLayer
    {
        private ApplicationDbContext db;

        public MyPageDAL(ApplicationDbContext indb)
        {
            db = indb;
        }

        public void ChangePhoto(string userID, int? imageID)
        {
            var page = GetMyPage(userID);
            page.pictureID = imageID;
            db.MyPage.Update(page);
            db.SaveChanges();
        }

        public void CreatePage(MyPage page)
        {
            db.Add(page);
            db.SaveChanges();
        }

        public void EditAboutMe(string userID, string message)
        {
            var page = GetMyPage(userID);
            page.aboutMe = message;
            db.MyPage.Update(page);
            db.SaveChanges();
        }

        public MyPage GetMyPage(string userID)
        {
            return db.MyPage.Where(m => m.userID == userID).FirstOrDefault();
        }

        public MyPage GetMyPage(int? pageID)
        {
            return db.MyPage.Where(m => m.Id == pageID).FirstOrDefault();
        }

        public IEnumerable<MyPage> Search(string key)
        {
            return db.MyPage.Where(k => k.userName.ToLower().Contains(key.ToLower()));
        }
    }
}
