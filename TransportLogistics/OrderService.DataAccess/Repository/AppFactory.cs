global using Microsoft.EntityFrameworkCore;
global using OrderService.DataAccess.Models;

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
        public DbSet<OSCustomer> customers { get; set; }
        public DbSet<OSUser> user { get; set; }
        public DbSet<Point> point { get; set; }
        public DbSet<OrderLine> ordersLine { get; set; }


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
