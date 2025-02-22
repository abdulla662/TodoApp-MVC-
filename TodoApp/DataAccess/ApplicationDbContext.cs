using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<TaskItem> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TodoApp;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
