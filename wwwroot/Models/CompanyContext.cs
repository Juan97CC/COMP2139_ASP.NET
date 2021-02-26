using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GbcSport.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>().HasData(

                new Country { CountryId = 1, CountryName = "Canada" },
                new Country { CountryId = 2, CountryName = "United States" },
                new Country { CountryId = 3, CountryName = "Mexico" },
                new Country { CountryId = 4, CountryName = "Puerto Rico" }

                );

            modelBuilder.Entity<Customer>().HasData(

                new Customer
                {
                    CustomerId = 1,
                    Firstname = "Juan",
                    Lastname = "Consuegra",
                    Email = "Juan.Consuegra@georgebrown.ca",
                    Phone = "905-000-0000",
                    City = "Mississauga",
                    CountryId = 1,
                    PostalCode = "ABC 123"

                },

                new Customer
                {
                    CustomerId = 2,
                    Firstname = "Jhonny",
                    Lastname = "Cash",
                    Email = "J.Caash@georgebrown.ca",
                    Phone = "911-000-0000",
                    City = "Austin",
                    CountryId = 2,
                    PostalCode = "234 123"

                }
                );

            modelBuilder.Entity<Technician>().HasData(

                 new Technician
                 {
                     TechnicianId = 1,
                     Firstname = "Peter",
                     Lastname = "Parker",
                     Email = "Parker@spiderman.com",
                     Phone = "222-999-1212"

                 },

                 new Technician
                 {
                     TechnicianId = 2,
                     Firstname = "Conor",
                     Lastname = "Mcgregor",
                     Email = "MrWhiskey@notorious.com",
                     Phone = "111-989-1212"

                 });

            modelBuilder.Entity<Product>().HasData(

                 new Product
                 {
                     ProductId = 1,
                     Code = "A1KW",
                     Productname = "UFC 300",
                     Price = "$59.99",
                     Releasedate = "Dec/12/21"
                 },
                 new Product
                 {
                     ProductId = 2,
                     Code = "NM2E",
                     Productname = "Nascar 211",
                     Price = "$9.99",
                     Releasedate = "Aug/22/21"
                 });

            modelBuilder.Entity<Incident>().HasData(

                 new Incident
                 {
                     IncidentId = 1,
                     CustomerId = 2,
                     ProductId = 1,
                     Title = "Error",
                     Description = "Product not proccessing",
                     DateAdded = DateTime.Now,
                     TechnicianId = 1
                 },

                 new Incident
                 {
                     IncidentId = 2,
                     CustomerId = 1,
                     ProductId = 2,
                     Title = " Big Error",
                     Description = "Product not found",
                     DateAdded = DateTime.Now,
                     TechnicianId = 2
                 }) ; 

        }

    }
}
