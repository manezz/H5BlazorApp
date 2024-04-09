using H5BlazorApp.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace H5BlazorApp.Data
{
    public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
    {
        public DbSet<Cpr> Cpr { get; set; }
        public DbSet<Todolist> Todolist { get; set; }
    }
}
