﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentReg.DataAccess;

namespace StudentReg.DataAccess.Migrations
{
    [DbContext(typeof(StudentRegDbContext))]
    [Migration("20210910100413_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentReg.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("StudentId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            AddressNo = "No.68",
                            City = "Wellawaya",
                            Street = "Newcity",
                            StudentId = 1
                        },
                        new
                        {
                            AddressId = 2,
                            AddressNo = "No.214",
                            City = "Beliatte",
                            Street = "Sitinamaluwa",
                            StudentId = 1
                        },
                        new
                        {
                            AddressId = 3,
                            AddressNo = "No.261",
                            City = "Wellawaya",
                            Street = "Buduruwagala Road",
                            StudentId = 2
                        },
                        new
                        {
                            AddressId = 4,
                            AddressNo = "No.06",
                            City = "Weliyaya",
                            Street = "rathmalweheragama",
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("StudentReg.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Age = 21,
                            FullName = "D.G.Lakshan",
                            Grade = "Year 01"
                        },
                        new
                        {
                            StudentId = 2,
                            Age = 20,
                            FullName = "D.G.Madhubashika",
                            Grade = "Year 01"
                        },
                        new
                        {
                            StudentId = 3,
                            Age = 22,
                            FullName = "Shan menaka",
                            Grade = "Year 02"
                        });
                });

            modelBuilder.Entity("StudentReg.Models.Address", b =>
                {
                    b.HasOne("StudentReg.Models.Student", "Student")
                        .WithMany("Address")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentReg.Models.Student", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
