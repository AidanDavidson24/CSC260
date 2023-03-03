using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data
{
    public class ImageDAL : IImageAccessLayer
    {
        private ApplicationDbContext db;

        public ImageDAL(ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddImage(Images imgae)
        {
            db.Images.Add(imgae);
            db.SaveChanges();
        }

        public IEnumerable<Images> GetImages(string? userID) 
        {
            return db.Images.Where(m => m.userID == userID).ToList();
        }

        public Images GetImage(int? id)
        { 
            return db.Images.Where(m => m.Id == id).FirstOrDefault();
        }

        public Images GetImage(string? name)
        { 
            return db.Images.Where(m => m.imageName == name).FirstOrDefault();
        }

        public void RemoveImage(int? id) 
        { 
            db.Images.Remove(GetImage(id));
        }
    }
}
