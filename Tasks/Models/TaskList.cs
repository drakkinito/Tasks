using System.Collections.Generic;

namespace Tasks.Models
{
    public class TaskList
    {
        public List<TaskModel> Items { get; set; }
        public Dictionary<int, string> States { get; set; }
        public FilterVM Filter { get; set; }
    }
}
