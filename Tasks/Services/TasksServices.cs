using System.Collections.Generic;
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

        public IEnumerable<TaskModel> GetTasks()
        {
            return _db.Tasks;
        }
        public void AddTask(TaskModel task) {
            _db.Tasks.Add(task);
            _db.SaveChangesAsync();
        }
        public int UpdateTask(TaskModel task) {
            return 200;
        }
        public int DeleteTask(int id) {
            return 200;
        }

    }
}
