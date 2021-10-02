using Microsoft.EntityFrameworkCore;
using StudentReg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg.DataAccess
{
    public class StudentRegDbContext : DbContext
    {
        public StudentRegDbContext(DbContextOptions<StudentRegDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=StudentRegDB;Trusted_Connection=True;MultipleActiveResultSets=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student{StudentId=1,FullName="D.G.Lakshan",Age=21,Grade="Year 01"},
                new Student{StudentId=2,FullName="D.G.Madhubashika",Age=20,Grade="Year 01"},
                new Student{StudentId=3,FullName="Shan menaka",Age=22,Grade="Year 02"}
            });

            modelBuilder.Entity<Address>().HasData(new Address[]
            {
                new Address{AddressId=1,AddressNo="No.68",Street="Newcity",City="Wellawaya",StudentId=01},
                new Address{AddressId=2,AddressNo="No.214",Street="Sitinamaluwa",City="Beliatte",StudentId=01},
                new Address{AddressId=3,AddressNo="No.261",Street="Buduruwagala Road",City="Wellawaya",StudentId=02},
                new Address{AddressId=4,AddressNo="No.06",Street="rathmalweheragama",City="Weliyaya",StudentId=03}
            });
        }

    }
}
