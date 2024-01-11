using Dotin.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotin.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

    }
}
