using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DataAccess
{
    public class AppContext : DbContext
    {
        //public DbSet<Customer> Customers => Set<Customer>();
        ////public AppContext() => Database.EnsureCreated();
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source = customers.db");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>().HasData(
        //            new Customer { Id = new Guid("8A3FC891-E7B1-447F-A9E8-86D47010001A"), Name = "ООО Рога и копыта", Address = "Урюпинск", ContactPerson = "Игорь", Email = "Horns_n_hooves@gmail.com", PhoneNumber = "777495999" },
        //            new Customer { Id = new Guid("6FA05EFC-D85E-4053-A838-CD56BB5AABA8"), Name = "ПАО Сбербанк", Address = "Москва", ContactPerson = "Герман", Email = "sbrf@gmail.com", PhoneNumber = "5556687" },
        //            new Customer { Id = new Guid("CA967885-E4AE-4343-B4AC-E22701FFF457"), Name = "Обособленное подразделение Управления ФНС России по Республике Бурятия в г. Улан-Удэ № 1", Address = "670047, г. Улан-Удэ, ул. Сахьяновой, д. 1а.", ContactPerson = "", Email = "fns@mail.ru", PhoneNumber = "8-800-222-2222" }
        //    );
        //}
    }
}
