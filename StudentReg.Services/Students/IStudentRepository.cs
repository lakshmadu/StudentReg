using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentReg.Models;


namespace StudentReg.Services.Students
{
    public interface IStudentRepository
    {
        public List<Student> GetStudent();
        public Student GetStudent(int id);
        //public List<Student> GetAllStudent();

        public Student AddStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(Student student, ICollection<Address> addresses);

        //Address oparation

        public Address GetAddress(int studentId, int addressId);

        public List<Address> GetAddresses(int addressId);

        public Address AddAddress(int studentId, Address address);

        public void UpdateAddress(Address address);

        public void DeleteAddress(Address address);
    }
}
