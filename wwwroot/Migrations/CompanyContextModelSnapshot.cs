﻿// <auto-generated />
using System;
using GbcSport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GbcSport.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GbcSport.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Mexico"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Puerto Rico"
                        });
                });

            modelBuilder.Entity("GbcSport.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            City = "Mississauga",
                            CountryId = 1,
                            Email = "Juan.Consuegra@georgebrown.ca",
                            Firstname = "Juan",
                            Lastname = "Consuegra",
                            Phone = "905-000-0000",
                            PostalCode = "ABC 123"
                        },
                        new
                        {
                            CustomerId = 2,
                            City = "Austin",
                            CountryId = 2,
                            Email = "J.Caash@georgebrown.ca",
                            Firstname = "Jhonny",
                            Lastname = "Cash",
                            Phone = "911-000-0000",
                            PostalCode = "234 123"
                        });
                });

            modelBuilder.Entity("GbcSport.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 2,
                            DateAdded = new DateTime(2021, 2, 15, 19, 18, 52, 66, DateTimeKind.Local).AddTicks(6359),
                            Description = "Product not proccessing",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Error"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 1,
                            DateAdded = new DateTime(2021, 2, 15, 19, 18, 52, 69, DateTimeKind.Local).AddTicks(6729),
                            Description = "Product not found",
                            ProductId = 2,
                            TechnicianId = 2,
                            Title = " Big Error"
                        });
                });

            modelBuilder.Entity("GbcSport.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Productname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Releasedate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "A1KW",
                            Price = "$59.99",
                            Productname = "UFC 300",
                            Releasedate = "Dec/12/21"
                        },
                        new
                        {
                            ProductId = 2,
                            Code = "NM2E",
                            Price = "$9.99",
                            Productname = "Nascar 211",
                            Releasedate = "Aug/22/21"
                        });
                });

            modelBuilder.Entity("GbcSport.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "Parker@spiderman.com",
                            Firstname = "Peter",
                            Lastname = "Parker",
                            Phone = "222-999-1212"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "MrWhiskey@notorious.com",
                            Firstname = "Conor",
                            Lastname = "Mcgregor",
                            Phone = "111-989-1212"
                        });
                });

            modelBuilder.Entity("GbcSport.Models.Customer", b =>
                {
                    b.HasOne("GbcSport.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("GbcSport.Models.Incident", b =>
                {
                    b.HasOne("GbcSport.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GbcSport.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GbcSport.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
