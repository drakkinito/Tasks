using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tasks.Models
{
    public class TaskList
    {
        public IEnumerable<TaskModel> Items { get; set; }
        public Dictionary<int, string> States { get; set; }
    }
}
