﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg.Services.Models
{
    public class StudentDto   
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Grade { get; set; }
    }
}
