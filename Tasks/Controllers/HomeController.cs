using Microsoft.AspNetCore.Mvc;
using Tasks.Services;
using Tasks.Models;
using System.Collections.Generic;
using Tasks.Models.Auth;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksServices _tasksService;
        private new Dictionary<int, string> _states;

        public HomeController(ITasksServices tasksService)
        {
            _tasksService = tasksService;
            _states = new Dictionary<int, string>() {
                    { 1, "All" },
                    { 2, "To do" },
                    { 3, "In Progress" },
                    { 4, "Done" }
                };
        }
        public IActionResult Index(FilterVM filter)
        {
            IEnumerable<TaskModel> taskItems = _tasksService.GetTasks(filter);


            ViewBag.Search = filter.Search;
            filter.StateName = filter.StateId > 0 ? _states[filter.StateId] : "All";

            var response = new TaskList
            {
                Items = taskItems,
                States = _states,
                Filter = filter
            };

            return View(response);
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
