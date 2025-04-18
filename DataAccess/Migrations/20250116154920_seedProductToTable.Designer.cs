﻿// <auto-generated />
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250116154920_seedProductToTable")]
    partial class seedProductToTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "History"
                        });
                });

            modelBuilder.Entity("Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("ListPrice100")
                        .HasColumnType("float");

                    b.Property<double>("ListPrice2")
                        .HasColumnType("float");

                    b.Property<double>("ListPrice50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Sabahattin Ali",
                            Description = "Güzel bir roman.",
                            ISBN = "1212454564",
                            ListPrice = 5.0,
                            ListPrice100 = 4.0,
                            ListPrice2 = 4.75,
                            ListPrice50 = 4.25,
                            Title = "Kuyucaklı Yusuf"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Sabahattin Ali",
                            Description = "Polisiye Romanı.",
                            ISBN = "3917854964",
                            ListPrice = 6.0,
                            ListPrice100 = 5.1500000000000004,
                            ListPrice2 = 5.7999999999999998,
                            ListPrice50 = 5.5,
                            Title = "Beyoglu Rapsodisi"
                        },
                        new
                        {
                            Id = 3,
                            Author = "İmam Gazali",
                            Description = "Genel kültür kitabı.",
                            ISBN = "6915445564",
                            ListPrice = 4.75,
                            ListPrice100 = 4.0,
                            ListPrice2 = 4.5,
                            ListPrice50 = 4.25,
                            Title = "Dil Belası"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
