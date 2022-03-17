using Microsoft.EntityFrameworkCore;

namespace Tasks.Context
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Models.TaskModel> Tasks { get; set;}

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
