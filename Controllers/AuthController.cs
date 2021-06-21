using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Areas.Identity.Data;

namespace RestaurantCMS.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<RestaurantCMSUser> _signInManager;
        public AuthController(SignInManager<RestaurantCMSUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
