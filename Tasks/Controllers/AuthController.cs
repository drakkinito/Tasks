using Microsoft.AspNetCore.Mvc;
using Tasks.Models.Auth;

namespace Tasks.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login() {
            return View();
        }

        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
                return Content($"{user.Name} - {user.Email}");
            else
                return View(user);
        }
    }
}
