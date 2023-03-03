using System.Diagnostics;
using MadLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace MadLib.Controllers
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

        [HttpPost]
        public IActionResult Madlib(string adj1, string n2, string adj3, string pn4, string av5, string v6, string sw7, string adj8, string pn9, string fn10, string adj11, string num12, string fn13, string fn14, string fn15, string fn16, string fn17, string fn18, string pn19)
        {
            ViewBag.adj1 = adj1;
            ViewBag.n2 = n2;
            ViewBag.adj3 = adj3;
            ViewBag.pn4 = pn4;
            ViewBag.av5 = av5;
            ViewBag.v6 = v6;
            ViewBag.sw7 = sw7;
            ViewBag.pn9 = pn9;
            ViewBag.fn10 = fn10;
            ViewBag.adj11 = adj11;
            ViewBag.num12 = num12;
            ViewBag.fn13 = fn13;
            ViewBag.fn14 = fn14;
            ViewBag.fn15 = fn15;
            ViewBag.fn16 = fn16;
            ViewBag.fn17 = fn17;
            ViewBag.fn18 = fn18;
            ViewBag.pn19 = pn19;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}