using Microsoft.EntityFrameworkCore;
using WebServer.Model;

namespace WebServer.Persistence
{
    public class Hi3Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Adult> Adults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\jodyc\RiderProjects\Handin2DNP\WebServer\Hi3.db");
        } 
    }
}