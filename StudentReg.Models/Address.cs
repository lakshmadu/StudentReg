using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg.Models
{
    public class Address
    {

        public int AddressId { get; set; }

        [Required]
        [MaxLength(15)]
        public string AddressNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
