global using Microsoft.EntityFrameworkCore;
global using OrderService.DataAccess.Models;
using TransportLogistics.Domain.Models.Customers;
using TransportLogistics.Domain.Models.Order;
using TransportLogistics.Domain.Models.Points;
using TransportLogistics.Domain.Models.Users;

namespace OrderService.DataAccess.Models
{
    public class AppFactory : DbContext
    {
        public AppFactory(DbContextOptions<AppFactory> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("name=ConnectionStrings:WebApiDatabase");
        }

        public DbSet<Orders> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Point> point { get; set; }
        public DbSet<OrderDetail> ordersLine { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>
            (
                entity =>
                {
                    entity.HasOne(x => x.PointOfDeparture).WithMany().HasForeignKey(x => x.PointOfDepartureId).OnDelete(DeleteBehavior.NoAction);
                    entity.HasOne(x => x.PointOfDestination).WithMany().HasForeignKey(x => x.PointOfDestinationId).OnDelete(DeleteBehavior.NoAction);
                }
            );
           
        }
    }
}
