﻿// <auto-generated />
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

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

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Sabahattin Ali",
                            CategoryID = 3,
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
                            CategoryID = 3,
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
                            CategoryID = 2,
                            Description = "Genel kültür kitabı.",
                            ISBN = "6915445564",
                            ListPrice = 4.75,
                            ListPrice100 = 4.0,
                            ListPrice2 = 4.5,
                            ListPrice50 = 4.25,
                            Title = "Dil Belası"
                        });
                });

            modelBuilder.Entity("Entity.Product", b =>
                {
                    b.HasOne("Entity.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Entity.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
