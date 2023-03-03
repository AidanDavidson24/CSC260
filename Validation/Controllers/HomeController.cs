using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Validation.Models;

namespace Validation.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public static List<Profile> profileList = new List<Profile>();

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Profile p)
		{
			if (ModelState.IsValid)
			{
				profileList.Add(p);
				TempData["success"] = "Profile added";
				return RedirectToAction("ViewProfile", "Home");
			}
			return View();
		}

		public IActionResult ViewProfile()
		{
			return View(profileList);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
    }
}