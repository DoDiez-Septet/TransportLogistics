using Microsoft.EntityFrameworkCore;
using UserService.DataAccess.ModelDb;
using TransportLogistics.Domain.Enums.Users;

namespace UserService.DataAccess;

internal class ApplicationDbContext : DbContext
{
    static bool _isDatabaseCreated = false;

    public DbSet<UserDb> Users { get; set; }

    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        //if (!_isDatabaseCreated)
        //{
        //    DataBaseRecreation();

        //    _isDatabaseCreated = true;
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //SeedDatabase(modelBuilder);
    }

    private void DataBaseRecreation()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        var students = new UserDb[]
            {
                new UserDb { Id = Guid.NewGuid(), FirstName = "Vasily", LastName = "Petrov", Email = "v.petrov@gmail.com", Password = "", Role = UserRole.Admin },
                new UserDb { Id = Guid.NewGuid(), FirstName = "Grigory", LastName = "Sidorov", Email = "g.sidorov@yandex.ru", Password = "", Role = UserRole.Admin },
                new UserDb { Id = Guid.NewGuid(), FirstName = "Anna", LastName = "Antonova", Email = "anna.antonova@yandex.ru", Password = "", Role = UserRole.Admin },
                new UserDb { Id = Guid.NewGuid(), FirstName = "Svatlana", LastName = "Vasileva", Email = "s.vasileva@rambler.ru", Password = "", Role = UserRole.Admin },
                new UserDb { Id = Guid.NewGuid(), FirstName = "Dmitry", LastName = "Nevedof", Email = "d.nefedov@gmail.com", Password = "", Role = UserRole.Admin }
            };

        modelBuilder.Entity<UserDb>().HasData(students);
    }
}