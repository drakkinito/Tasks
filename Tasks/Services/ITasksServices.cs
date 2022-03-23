using System.Collections.Generic;
using TaskModel = Tasks.Models.TaskModel;

namespace Tasks.Services
{
    public interface ITasksServices
    {
        public IEnumerable<TaskModel> GetTasks(string search);
        public TaskModel Get(int id);
        public void Update(TaskModel task);
        public void Add(TaskModel task);
        public void Delete(int id);
    }
}
