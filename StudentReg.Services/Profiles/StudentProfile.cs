using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentReg.Models;
using StudentReg.Services.Models;


namespace StudentReg.Services.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
