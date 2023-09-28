using DemoASPMVC.Models.ViewModel;
using DemoASPMVC_DAL.Interface;
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
            if(!ModelState.IsValid)
            {
                return View(u);
            }

            if(_userService.Register(u.Email, u.Password, u.Nickname)) 
            {
                return RedirectToAction("Index", "Game") ;
            }

            return View();

        }
    }
}
