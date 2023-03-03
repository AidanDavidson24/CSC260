using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers
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
			return View();
		}

		public IActionResult HomePage()
		{
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Cow(int? id)
		{
			if (id == null) return NotFound();
			return Content($"The cow Default Cow moos at you {id?.ToString()} times.");
		}

		public IActionResult Chicken()
		{
			return Redirect("https://www.chick-fil-a.com/");
		}

		public IActionResult Cow2(int? id, string? cow)
		{
			if (id == null) return NotFound();
			if (cow != null) return Content($"The cow {cow} moos at you {id?.ToString()} times.");
			return Content($"The cow Default Cow moos at you {id?.ToString()} times.");
		}

		public IActionResult CowGallery(int? id)
		{
			if (id == null) return NotFound();
			return Content($"There are {id.ToString()} cows on this page");
		}

		public IActionResult CowGallery2(int? id, int? num)
		{
			if (id == null || num == null) return NotFound();
			return Content($"There are {id.ToString()} cows on page {num.ToString()}");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}