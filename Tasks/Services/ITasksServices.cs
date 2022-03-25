using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.Services
{
    public interface ITasksServices
    {
        public IEnumerable<TaskModel> GetTasks(FilterVM filter);
        public TaskModel Get(int id);
        public void Update(TaskModel task);
        public void Add(TaskModel task);
        public void Delete(int id);
    }
}
