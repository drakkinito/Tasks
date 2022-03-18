using System.Collections.Generic;
using System.Linq;
using Tasks.Context;
using Tasks.Models;

namespace Tasks.Services
{
    public class TasksServices : ITasksServices 
    {
        private TaskDbContext _db;
        public TasksServices(TaskDbContext context)
        {
            _db = context;
        }

        public IEnumerable<TaskModel> GetTasks(string search)
        {
            IQueryable<TaskModel> data = _db.Set<TaskModel>();

            if (!string.IsNullOrEmpty(search))
            {
                return data.Where(t => t.Title.Contains(search) || t.Describe.Contains(search)).ToList();
            }

            return data.ToList();
        }

        public void AddTask(TaskModel task) {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public int UpdateTask(TaskModel task) {
            return 200;
        }

        public int DeleteTask(int id) {
            return 200;
        }

    }
}
