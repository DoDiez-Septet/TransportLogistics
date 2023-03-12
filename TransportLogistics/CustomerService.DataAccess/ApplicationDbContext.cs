using Microsoft.EntityFrameworkCore;
using CustomerService.DataAccess.Models;

namespace CustomerService.DataAccess
{
    internal class ApplicationDbContext : DbContext
    {
        static bool _isDatabaseCreated = false;

        public DbSet<CustomerDb> Customers { get; set; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            if (!_isDatabaseCreated)
            {
                DataBaseRecreation();

                _isDatabaseCreated = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedDatabase(modelBuilder);
        }

        private void DataBaseRecreation()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            var customers = new CustomerDb[]
                {
                    new CustomerDb { Id = new Guid("8A3FC891-E7B1-447F-A9E8-86D47010001A"), Name = "ООО Рога и копыта", Address = "Урюпинск", ContactPerson = "Игорь", Email = "Horns_n_hooves@gmail.com", PhoneNumber = "777495999" },
                    new CustomerDb { Id = new Guid("6FA05EFC-D85E-4053-A838-CD56BB5AABA8"), Name = "ПАО Сбербанк", Address = "Москва", ContactPerson = "Герман", Email = "sbrf@gmail.com", PhoneNumber = "5556687" },
                    new CustomerDb { Id = new Guid("CA967885-E4AE-4343-B4AC-E22701FFF457"), Name = "Обособленное подразделение Управления ФНС России по Республике Бурятия в г. Улан-Удэ № 1", Address = "670047, г. Улан-Удэ, ул. Сахьяновой, д. 1а.", ContactPerson = "", Email = "fns@mail.ru", PhoneNumber = "8-800-222-2222" }
                };

            modelBuilder.Entity<CustomerDb>().HasData(customers);
        }
    }
}