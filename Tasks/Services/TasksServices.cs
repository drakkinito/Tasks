using System;
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

        public ICollection<TaskModel> GetTasks(FilterVM filter)
        {
            IQueryable<TaskModel> data = _db.Set<TaskModel>();

            if (!string.IsNullOrEmpty(filter.Search))
            {
                data = data.Where(t => t.Title.Contains(filter.Search) || t.Describe.Contains(filter.Search));
            }
            if (filter.StateOrder > 0)
            {
                data = data.Where(t => t.StateId == filter.StateOrder);
            }

            return data.ToList();
        }

        public TaskModel Get(int id)
        {
            return _db.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TaskModel task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public bool Update(TaskModel task)
        {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (data != null)
            {
                data.Title = task.Title;
                data.Describe = task.Describe;
                data.StateId = task.StateId;
                data.StartDate = task.StartDate;
                _db.SaveChanges();
            }

            return data != null;
        }

        public bool UpdateState(int id, int stateId)
        {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == id);
            if (data != null)
            {
                data.StateId = stateId;
                _db.SaveChanges();
            }

            return data != null;
        }

        public bool Delete(int id)
        {
            var data = _db.Tasks.FirstOrDefault(t => t.Id == id);
            if (data != null)
            {
                _db.Tasks.Remove(data);
                _db.SaveChanges();
            }

            return data != null;
        }
    }
}
