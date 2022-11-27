using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoModel> TodoModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}