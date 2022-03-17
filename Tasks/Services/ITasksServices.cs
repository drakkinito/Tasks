using System.Collections.Generic;
using TaskModel = Tasks.Models.TaskModel;

namespace Tasks.Services
{
    public interface ITasksServices
    {
        public IEnumerable<TaskModel> GetTasks();
        public void AddTask(TaskModel task);
        public int UpdateTask(TaskModel task);
        public int DeleteTask(int id);
    }
}
