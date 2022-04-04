using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.Services
{
    public interface ITasksServices
    {
        public List<TaskModel> GetTasks(FilterVM filter);
        public TaskModel Get(int id);
        public bool Update(TaskModel task);
        public bool UpdateState(int id, int stateId);
        public void Add(TaskModel task);
        public bool Delete(int id);
    }
}
