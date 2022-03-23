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

        public TaskModel Get(int id)
        {
            return _db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskModel task) {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void Update(TaskModel task) {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            data.Title = task.Title;
            data.Describe = task.Describe;

            _db.SaveChanges();
        }

        public void Delete(int id) {
            var task = _db.Tasks.FirstOrDefault(t => t.Id == id);

            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
    }
}
