﻿using Microsoft.AspNetCore.Mvc;
using Tasks.Services;
using Tasks.Models;
using System.Collections.Generic;
using Tasks.Models.Auth;
using System.Linq;

namespace Tasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITasksServices _tasksService;
        private readonly Dictionary<int, string> _states;

        public HomeController(ITasksServices tasksService)
        {
            _tasksService = tasksService;
            _states = new Dictionary<int, string>() {
                    { 0, "All" },
                    { 1, "To do" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                };
        }
        public IActionResult Index(FilterVM filter)
        {
          List<TaskModel> taskItems = _tasksService.GetTasks(filter);

           
            ViewBag.Search = filter.Search;
            ViewBag.IsAuth = false;
            filter.StateName = _states[filter.StateOrder];

            var response = new TaskList
            {
                Items = taskItems,
                States = _states,
                Filter = filter
            };

            return View(response);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            TaskModel task = _tasksService.Get(id);
            if (task == null) {
                return BadRequest();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (task == null) {
                return BadRequest();
            }

            if (!string.IsNullOrEmpty(task.Title) || !string.IsNullOrEmpty(task.Describe))
            {
                _tasksService.Add(task);
            }

            return RedirectToAction("Index");
        }
     
        public IActionResult Update(TaskModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            if (!_tasksService.Update(task)) {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateState(int id, int stateId)
        {
            if (!_tasksService.UpdateState(id, stateId)) {
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!_tasksService.Delete(id)) { 
                return BadRequest();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
