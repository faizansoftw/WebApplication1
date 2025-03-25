using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
