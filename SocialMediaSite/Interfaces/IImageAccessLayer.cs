using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Models;

namespace SocialMediaSite.Interfaces
{
    public interface IImageAccessLayer
    {
        public IEnumerable<Images> GetImages(string? userID);
        public Images GetImage(int? id);
        public Images GetImage(string? name);
        public void AddImage(Images imgae);
        public void RemoveImage(int? id);
    }
}
