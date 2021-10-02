using StudentReg.Models;
using StudentReg.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg.Services.Students
{
    public class StudentSqlSeverRepository : IStudentRepository  
    {
        private readonly StudentRegDbContext _context;

        public StudentSqlSeverRepository(StudentRegDbContext context)
        {
            this._context = context;
        }

        public List<Student> GetStudent()
        {
            return _context.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return _context.Students.Find(student.StudentId);
        }
        public void UpdateStudent(Student student)
        {
            _context.SaveChanges();


        }

        public void DeleteStudent(Student student, ICollection<Address> addresses)
        {
            _context.Students.Remove(student);
            foreach(var address in addresses)
            {
                _context.Addresses.Remove(address);
            }

            _context.SaveChanges();
        }


        //address oparations;
        public Address GetAddress(int studentId, int addressId)
        {
            return _context.Addresses.FirstOrDefault(t => t.StudentId == studentId && t.AddressId == addressId);

        }
        public List<Address> GetAddresses(int studentId)
        {
            return _context.Addresses.Where(t => t.StudentId == studentId).ToList();
        }

        public Address AddAddress(int studentId, Address address)
        {
            address.StudentId = studentId;
            _context.Add(address);
            _context.SaveChanges();

            return _context.Addresses.Find(address.AddressId);
        }

        public void UpdateAddress(Address address)
        {
            _context.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            _context.Remove(address);
            _context.SaveChanges();
        }
    }
}
