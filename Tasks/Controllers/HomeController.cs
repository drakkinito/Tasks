using Microsoft.AspNetCore.Mvc;
using Tasks.Services;
using Tasks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksServices _tasksService;
        public HomeController(ITasksServices tasksService)
        {
            _tasksService = tasksService;
        }
        public IActionResult Index()
        {
            var list = _tasksService.GetTasks().ToList();

            return View(list.AsEnumerable());
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
