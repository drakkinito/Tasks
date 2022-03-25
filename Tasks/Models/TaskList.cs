using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Tasks.Models
{
    public class TaskList
    {
        public IEnumerable<TaskModel> Items { get; set; }
        public Dictionary<string, string> States { get; set; }
    }
}
