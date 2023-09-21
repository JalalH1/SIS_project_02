using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project_Info_Jalal_Harb.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
