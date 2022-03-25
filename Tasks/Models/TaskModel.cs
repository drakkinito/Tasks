namespace Tasks.Models
{
    public class TaskModel : BaseModel
    {
        public string Title { get; set; }
        public string Describe { get; set; }
        public int StateId { get; set; }
    }
}
