using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentReg.Models;
namespace StudentReg.Services.Models
{
    public class CreateStudentDto
    {
        
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
        public ICollection<AddressDto> Address { get; set; } = new List<AddressDto>();
    }
}
