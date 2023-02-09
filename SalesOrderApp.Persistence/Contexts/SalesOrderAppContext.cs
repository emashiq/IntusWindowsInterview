using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SalesOrderApp.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderApp.Persistence.Contexts
{
    public class SalesOrderAppContext : DbContext
    {
        public SalesOrderAppContext(DbContextOptions<SalesOrderAppContext> options ):base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(x =>
            {
                x.HasKey("Id");
                x.HasMany(c => c.Windows)
                .WithOne(g => g.Order);
            });

            modelBuilder.Entity<Window>(x =>
            {
                x.HasKey("Id");
                x.HasMany(p => p.SubElements)
                .WithOne(p => p.Window);
            });

            modelBuilder.Entity<SubElement>().HasKey("Id");
            base.OnModelCreating(modelBuilder);
        }
    }
}
