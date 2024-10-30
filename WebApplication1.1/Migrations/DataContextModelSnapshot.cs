﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1._1.Data;

#nullable disable

namespace WebApplication1._1.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1._1.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 6,
                            Name = "MicroPhone1",
                            Price = 16.0
                        },
                        new
                        {
                            Id = 2,
                            Amount = 7,
                            Name = "MicroPhone2",
                            Price = 95.0
                        },
                        new
                        {
                            Id = 3,
                            Amount = 7,
                            Name = "MicroPhone3",
                            Price = 62.0
                        },
                        new
                        {
                            Id = 4,
                            Amount = 5,
                            Name = "MicroPhone4",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 5,
                            Amount = 4,
                            Name = "MicroPhone5",
                            Price = 70.0
                        },
                        new
                        {
                            Id = 6,
                            Amount = 6,
                            Name = "MicroPhone6",
                            Price = 48.0
                        },
                        new
                        {
                            Id = 7,
                            Amount = 2,
                            Name = "MicroPhone7",
                            Price = 58.0
                        },
                        new
                        {
                            Id = 8,
                            Amount = 5,
                            Name = "MicroPhone8",
                            Price = 33.0
                        },
                        new
                        {
                            Id = 9,
                            Amount = 2,
                            Name = "MicroPhone9",
                            Price = 88.0
                        },
                        new
                        {
                            Id = 10,
                            Amount = 3,
                            Name = "MicroPhone10",
                            Price = 66.0
                        },
                        new
                        {
                            Id = 11,
                            Amount = 1,
                            Name = "MicroPhone11",
                            Price = 45.0
                        },
                        new
                        {
                            Id = 12,
                            Amount = 4,
                            Name = "MicroPhone12",
                            Price = 75.0
                        },
                        new
                        {
                            Id = 13,
                            Amount = 6,
                            Name = "MicroPhone13",
                            Price = 97.0
                        },
                        new
                        {
                            Id = 14,
                            Amount = 4,
                            Name = "MicroPhone14",
                            Price = 93.0
                        },
                        new
                        {
                            Id = 15,
                            Amount = 5,
                            Name = "MicroPhone15",
                            Price = 17.0
                        },
                        new
                        {
                            Id = 16,
                            Amount = 9,
                            Name = "MicroPhone16",
                            Price = 74.0
                        },
                        new
                        {
                            Id = 17,
                            Amount = 3,
                            Name = "MicroPhone17",
                            Price = 88.0
                        },
                        new
                        {
                            Id = 18,
                            Amount = 1,
                            Name = "MicroPhone18",
                            Price = 13.0
                        },
                        new
                        {
                            Id = 19,
                            Amount = 4,
                            Name = "MicroPhone19",
                            Price = 80.0
                        },
                        new
                        {
                            Id = 20,
                            Amount = 6,
                            Name = "MicroPhone20",
                            Price = 87.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}