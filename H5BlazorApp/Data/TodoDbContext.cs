using H5BlazorApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace H5BlazorApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<Cpr> Cpr { get; set; }
        public DbSet<Todolist> Todolist { get; set; }
    }
}
