using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSite.Data;
using SocialMediaSite.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SocialMediaSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (User.Identity != null && User.Identity.IsAuthenticated)
			{ 
				return RedirectToAction("MyPage", "myPage");
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult About() 
		{
			return View();
		}

		//[Authorize]
		//public IActionResult MyPage()
		//{
		//	return View(User.FindFirstValue(ClaimTypes.Name));
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}