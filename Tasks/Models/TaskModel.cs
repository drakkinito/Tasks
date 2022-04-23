using Microsoft.AspNetCore.Mvc;
using System;

namespace Tasks.Models
{
    public class TaskModel : BaseModel
    {
        public string Title { get; set; }
        public string Describe { get; set; }
        public int StateId { get; set; }
        [BindProperty]
        public DateTime StartDate { get; set; }
    }
}
