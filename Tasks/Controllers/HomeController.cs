using Microsoft.AspNetCore.Mvc;
using Tasks.Services;
using Tasks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksServices _tasksService;
        public HomeController(ITasksServices tasksService)
        {
            _tasksService = tasksService;
        }
        public IActionResult Index(string search)
        {
            IEnumerable<TaskModel> list = _tasksService.GetTasks(search).ToList();
            ViewBag.Search = search;

            return View(list);
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (!string.IsNullOrEmpty(task.Title) || !string.IsNullOrEmpty(task.Describe))
            {
                _tasksService.AddTask(task);
            }

            return RedirectToAction("Index");
        }
    }
}
