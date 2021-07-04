using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCrud.Model;

namespace WebApiCrud.Controllers
{
    //[Route("api/Student")]
    //[ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> _oStudents = new List<Student>()
        {
            new Student() { Id = 1, Name = "kunal", Roll = 101 },
            new Student() { Id = 2, Name = "Harsh", Roll = 102 },
            new Student() { Id = 3, Name = "mandeep", Roll = 103 },
            new Student() { Id = 4, Name = "mohit", Roll = 104 },
            new Student() { Id = 5, Name = "mukul", Roll = 105 }
        };
        [Route("Student/Get")]
        [HttpGet]
        public async Task<IActionResult> Gets()
        {
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        [Route("Student/Get/{id}")]
        [HttpGet("GetStudent")]
        public async Task<IActionResult> Get(int id)
        {
            var ostudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (ostudent == null)
            {
                return NotFound("No Student Found");
            }
            return Ok(ostudent);
        }
        [Route("Student/Save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Student oStudent)
        {
            _oStudents.Add(oStudent);
            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

        [Route("Student/PutUpdate/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutUpdate(int id,[FromBody] Student oStudent)
        {
            if (id != oStudent.Id)
            {
                return BadRequest("Id does not match");
            }

            var result = _oStudents.SingleOrDefault(x => x.Id == id);
            if(result != null && result.Name != oStudent.Name && result.Roll != oStudent.Roll)
            {
                result.Id = oStudent.Id;
                result.Name = oStudent.Name;
                result.Roll = oStudent.Roll;
                return Ok(_oStudents);
            }
            else
            {
                return BadRequest("wrong method");
            } 
        }

        [Route("Student/PatchUpdate/{id}")]
        [HttpPatch]
        public async Task<IActionResult> PatchUpdate(int id, [FromBody] Student oStudent)
        {
            if (id != oStudent.Id)
            {
                return BadRequest("Id does not match");
            }

            var result = _oStudents.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Id = oStudent.Id;
                result.Name = oStudent.Name;
                result.Roll = oStudent.Roll;
                return Ok(_oStudents);
            }
            else
            {
                return BadRequest("wrong method");
            }
        }

        [Route("Student/Delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var ostudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (ostudent == null)
            {
                return NotFound("No Student Found");
            }
            _oStudents.Remove(ostudent);

            if (_oStudents.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oStudents);
        }

       
    }
}
