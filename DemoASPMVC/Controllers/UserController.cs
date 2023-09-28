using DemoASPMVC.Models.ViewModel;
using DemoASPMVC_DAL.Interface;
using DemoASPMVC_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoASPMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterForm u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            if (_userService.Register(u.Email, u.Password, u.Nickname))
            {
                return RedirectToAction("Index", "Game");
            }

            return View();

        }

        public IActionResult Login()
        {
            ViewData["toto"] = DateTime.Now;
            TempData["bidule"] = "jean maurice";
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginForm u)
        {
            try
            {
                User connectedUser = _userService.Login(u.Email, u.Password);
                return Ok(connectedUser);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}
