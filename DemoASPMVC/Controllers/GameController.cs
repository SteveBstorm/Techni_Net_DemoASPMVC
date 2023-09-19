using DemoASPMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPMVC.Controllers
{
    public class GameController : Controller
    {
        GameService gameService { get; set; }
        public GameController()
        {
            gameService = new GameService();
        }
        public IActionResult Index()
        {
            
            return View(gameService.GetGames());
        }

        public IActionResult Details(int id)
        {
            return View(gameService.GetById(id));
        }
    }
}
