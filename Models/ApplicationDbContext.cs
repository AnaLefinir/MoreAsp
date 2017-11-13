using System;
using Microsoft.EntityFrameworkCore;

namespace MoreAsp.Models
{
    public class ApplicationDbContext : DbContext
    {
        /*
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }*/

        //Use DbSet to define tables and views
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("default");
            base.OnConfiguring(options);
        }
    }
}