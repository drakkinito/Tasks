using System.Collections.Generic;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class DisplaySection
    {  
        public List<TaskModel> Items { get; set; }
        public Dictionary<int, string> States { get; set; }
        public string StyleValue { get; set; }
    }
}
