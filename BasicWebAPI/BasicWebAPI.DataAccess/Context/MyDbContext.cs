using BasicWebAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.DataAccess.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
