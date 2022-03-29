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

        public IEnumerable<TaskModel> GetTasks(FilterVM filter)
        {
            
            IQueryable<TaskModel> data = _db.Set<TaskModel>();

            return data.Where(t =>
                             (t.Title.Contains(filter.Search ?? "") || t.Describe.Contains(filter.Search ?? "")) &&
                             (filter.StateId == 0 ? t.StateId > 0 : t.StateId == filter.StateId)).ToList();
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
            data.StateId = task.StateId;

            _db.SaveChanges();
        }

        public void Delete(int id) {
            var task = _db.Tasks.FirstOrDefault(t => t.Id == id);

            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
    }
}
