using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameList.Data;
using VideoGameList.Interface;
using VideoGameList.Models;

namespace VideoGameList.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //IDataAccessLayer dal = new GameListDAL();
        IDataAccessLayer dal;
        public HomeController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Games game)
        {
            if (ModelState.IsValid)
            {
                dal.AddGame(game);
                TempData["success"] = game.Title + " added.";
                return RedirectToAction("Collection", "Home");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            dal.RemoveGame(id);
            TempData["success"] = "Game Removed";
            return RedirectToAction("Collection", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            return View(dal.GetGame(id));
        }

        [HttpPost]
        public IActionResult Edit(Games game)
        {
            dal.EditGame(game);
            TempData["success"] = "'" + game.Title + "' Updated";
            return RedirectToAction("Collection", "Home");
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("Collection", dal.GetGames());
            }
            return View("Collection", dal.GetGames().Where(x => x.Title.ToLower().Contains(key.ToLower())));
        }

        [HttpGet]
        public IActionResult Collection()
        {
            return View(dal.GetGames());
        }

        [HttpPost]
        public IActionResult Collection(int? id, string LoanedTo)
        {
            dal.LoanGame(id, LoanedTo);
            return View(dal.GetGames());
        }

        [HttpPost]
        public IActionResult Return(int? id)
        {
            dal.ReturnGame(id);
            return RedirectToAction("Collection", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Filter(string Genre, string platform)
        {
            return View("Collection", dal.FilterGames(Genre, platform));
        }
    }
}