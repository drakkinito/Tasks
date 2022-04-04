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

        public List<TaskModel> GetTasks(FilterVM filter)
        {
            
            IQueryable<TaskModel> data = _db.Set<TaskModel>();

            if (!string.IsNullOrEmpty(filter.Search)) {
                data = data.Where(t => t.Title.Contains(filter.Search) || t.Describe.Contains(filter.Search));
            }
            if (filter.StateOrder > 0) {
                data = data.Where(t => t.StateId == filter.StateOrder);
            }

            var items = data.OrderBy(t => t.StateId).ToList();

            var filterItems = new Dictionary<int, List<TaskModel>>
            {
                { 1, items.Where(t => t.StateId == 1).ToList()},
                { 2, items.Where(t => t.StateId == 2).ToList()},
                { 3, items.Where(t => t.StateId == 3).ToList()}
            };

            return items;
        }

        public TaskModel Get(int id)
        {
            return _db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskModel task) {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public bool Update(TaskModel task) {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (data == null) {
                return false;
            }

            data.Title = task.Title;
            data.Describe = task.Describe;
            data.StateId = task.StateId;
            _db.SaveChanges();

            return true;
        }
        public bool UpdateState(int id, int stateId)
        {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == id);
            if (data == null) {
                return false;
            }

            data.StateId = stateId;
            _db.SaveChanges();

            return true;
        }

        public bool Delete(int id) {
            var task = _db.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null) {
                return false;
            }

            _db.Tasks.Remove(task);
            _db.SaveChanges();

            return true;
        }
    }
}
