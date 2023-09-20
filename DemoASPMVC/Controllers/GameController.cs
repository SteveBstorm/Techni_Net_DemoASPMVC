using DemoASPMVC.Models;
using DemoASPMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPMVC.Controllers
{
    public class GameController : Controller
    {
        GameService gameService { get; set; }
        public GameController(GameService gs)
        {
            gameService = gs;
        }
        public IActionResult Index()
        {
            
            return View(gameService.GetGames());
        }

        public IActionResult Details(int id)
        {
            return View(gameService.GetById(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game g)
        {
            gameService.Create(g);
            return RedirectToAction("Index");
        }
    }
}
