using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(50)]
        public string Grade { get; set; }

        public ICollection<Address> Address { get; set; } = new List<Address>();
    }
}
