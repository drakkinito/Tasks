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

        [HttpGet]
        public IActionResult Get(int id)
        {
            TaskModel task = _tasksService.Get(id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (!string.IsNullOrEmpty(task.Title) || !string.IsNullOrEmpty(task.Describe))
            {
                _tasksService.Add(task);
            }

            return RedirectToAction("Index");
        }
     
        public IActionResult Update(TaskModel task)
        {
            _tasksService.Update(task);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _tasksService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
