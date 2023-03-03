using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialMediaSite.Interfaces;
using SocialMediaSite.Models;
using System.Dynamic;
using System.Security.Claims;

namespace SocialMediaSite.Controllers
{
    public class myPageController : Controller
    {
        IMyPageAccessLayer DAL;
        IImageAccessLayer DAL2;
        ICommentsAccessLayer DAL3;
        
        public myPageController(IMyPageAccessLayer dal, IImageAccessLayer dAL2, ICommentsAccessLayer dal3)
        {
            DAL = dal;
            DAL2 = dAL2;
            DAL3 = dal3;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyPage()
        {
            MyPage page;
            page = DAL.GetMyPage(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (page != null)
            {
                ViewBag.Image = DAL2.GetImage(page.pictureID).imageName;
                var coms = DAL3.GetComments(page.Id);
                List<CommentStuff> comments = new List<CommentStuff>();
                foreach (var comment in coms)
                {
                    comments.Add(new CommentStuff(comment, comment.userName, page.userID));
                }
                return View(new MyPageImage(page, comments));
            }
            else if (DAL2.GetImages(User.FindFirstValue(ClaimTypes.NameIdentifier)).Count() < 1)
            {
                return RedirectToAction("UploadPhoto", "Image");
            }
            else
            {
                return CreateMyPage();
            }
        }

        [Authorize]
        [HttpGet]
        //[Route("/{userID?}")]
        public IActionResult OtherPage(string? userID)
        {
            if (userID == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Redirect("MyPage");
            }

            MyPage page;
            page = DAL.GetMyPage(userID);

            if (page != null)
            {
                ViewBag.Image = DAL2.GetImage(page.pictureID).imageName;
                var coms = DAL3.GetComments(page.Id);
                List<CommentStuff> comments = new List<CommentStuff>();
                foreach (var comment in coms)
                { 
                    comments.Add(new CommentStuff(comment, comment.userName, page.userID));
                }
                return View(new MyPageImage(page, comments));
            }
            else
            {
                return Redirect("MyPage");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateMyPage()
        {
            var images = DAL2.GetImages(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var viewModel = new MyPageImage(new MyPage(), new SelectList(images, "Id", "imageName"));
            return View("CreateMyPage", viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateMyPage(MyPageImage page) 
        {
            page.myPages.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            page.myPages.userName = User.FindFirstValue(ClaimTypes.Email);
            if (page.myPages.aboutMe.Contains("\r\n"))
            { 
                page.myPages.aboutMe = page.myPages.aboutMe.Replace("\r\n", "<br />");
            }
            DAL.CreatePage(page.myPages);
            return Redirect("MyPage");
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditMyPage() 
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var page = new MyPageImage(DAL.GetMyPage(uid), new SelectList(DAL2.GetImages(uid), "Id", "imageName"));
            return View(page);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditMyPage(MyPageImage page)
        {
            page.myPages.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (page.myPages.aboutMe.Contains("\r\n"))
            {
                page.myPages.aboutMe = page.myPages.aboutMe.Replace("\r\n", "<br />");
            }
            DAL.EditAboutMe(User.FindFirstValue(ClaimTypes.NameIdentifier), page.myPages.aboutMe);
            DAL.ChangePhoto(User.FindFirstValue(ClaimTypes.NameIdentifier), page.myPages.pictureID);
            return Redirect("MyPage");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddComment(Comments comment)
        {
            comment.userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            comment.userName = User.FindFirstValue(ClaimTypes.Email);
            DAL3.AddComment(comment);
            //OtherPage(DAL.GetMyPage(comment.pageID).userID);
            return RedirectToAction("OtherPage", "myPage", new { @userID = DAL.GetMyPage(comment.pageID).userID });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Results(string key)
        {
            return View(DAL.Search(key));
        }
    }
}
