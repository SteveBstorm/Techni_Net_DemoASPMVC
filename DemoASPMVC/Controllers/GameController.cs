using DemoASPMVC.Models;
using DemoASPMVC.Services;
using DemoASPMVC.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPMVC.Controllers
{
    public class GameController : Controller
    {
        //Injection de l'instance du service via le constructeur du controller
        //GameService gameService { get; set; }
        
        private readonly IGameService gameService;
        public GameController(IGameService gs)
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

        [CustomAuthorize]
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
        [CustomAuthorize]
        public IActionResult Delete(int id)
        {
            //scoped => on garde l'instance durant tout le traitement de l'action Delete
            //Game game = gameService.GetById(id);
            gameService.Delete(id);
            return RedirectToAction("Index");

            //Transient => on crée une nouvelle instance, à chaque fois que le service est appelé
        }
    }
}
