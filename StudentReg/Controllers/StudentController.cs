using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentReg.Services.Students;

using AutoMapper;
using StudentReg.Services.Models;
using StudentReg.Models;

namespace StudentReg.Controllers
{
    [Route("api/student")]
    [Controller]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _service;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            
        }


        //get one student
        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int StudentId)
        {
            var student = _service.GetStudent(StudentId);

            if (student is null)
            {
                return NotFound();
            }

            var mappedStudent = _mapper.Map<StudentDto>(student);
            return Ok(mappedStudent);
        }

        [HttpPost]
        public ActionResult<StudentDto> CreateStudent([FromBody] CreateStudentDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);

            var newStudent = _service.AddStudent(studentEntity);

            var StudentForReturn = _mapper.Map<StudentDto>(newStudent);

            return CreatedAtRoute("GetStudent", new { id = StudentForReturn.StudentId }, StudentForReturn);
        }

        [HttpPut("{studentId}")]
        public ActionResult UpdateStudent(int studentId,[FromBody]UpdateStudentDto student)
        {
            var updatingStudent = _service.GetStudent(studentId);

            if(updatingStudent is null)
            {
                return NotFound();
            }

            var newAddress= _mapper.Map(student, updatingStudent);
            _service.UpdateStudent(updatingStudent);

            return NoContent();


        }

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            var student = _service.GetStudent(studentId);
            var address = _service.GetAddresses(studentId);

            _service.DeleteStudent(student,address);

            return NoContent();
        }



    }
}
