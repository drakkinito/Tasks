using Microsoft.AspNetCore.Mvc;

namespace Tasks.Controllers
{
    public class HistotyController : Controller
    {
        public IActionResult GetHistory()
        {
            return View();
        }
    }
}
