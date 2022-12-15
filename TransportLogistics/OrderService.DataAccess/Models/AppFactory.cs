using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.DataAccess.Models
{
    public class AppFactory : DbContext
    {
        public AppFactory(DbContextOptions<AppFactory> options) : base(options)
        { }

        public DbSet<Orders> orders { get; set; }
        public DbSet<OSCustomer> customers { get; set; }
        public DbSet<OSUser> user { get; set; }
        public DbSet<Point> point { get; set; }
        public DbSet<OrderLine> ordersLine { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
                entity.HasOne(x => x.PointOfDeparture).WithMany().HasForeignKey(x => x.PointOfDepartureId).OnDelete(DeleteBehavior.NoAction)
                );
            modelBuilder.Entity<Orders>(entity =>
                entity.HasOne(x => x.PointOfDestination).WithMany().HasForeignKey(x => x.PointOfDestinationId).OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
}
