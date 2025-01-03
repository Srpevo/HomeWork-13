using HomeWork_13.Core.Classes.Student;
using HomeWork_13.Core.Classes.StudentModel;
using HomeWork_13.Core.Structs.StudentMetData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HomeWork_13.Core.Controllers.StudentController
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private static List<Student> _students = new List<Student>();

        private Student? FindStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("Add Student")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid student data");
            }
            _students.Add(student);
            return Ok("New student added");
        }

        [HttpPost("Update Student")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentModel studentModel)
        {
            if (studentModel == null)
            {
                return BadRequest("Invalid data");
            }

            var student = FindStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            student.Name = studentModel.Name;
            student.StudentMetData = studentModel.StudentMetData;
            return Ok("Student updated successfully");
        }

        [HttpDelete("Delete Student")]
        public IActionResult DeleteStudent(int id)
        {
            var student = FindStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            _students.Remove(student);
            return Ok("Student deleted successfully");
        }

        [HttpGet("Login")]
        public IActionResult Login(string userName, string password)
        {
            var student = _students.FirstOrDefault(x => x.UserName == userName);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            if (student.Password == password)
            {
                return Ok("Successful login");
            }
            else
            {
                return BadRequest("Invalid password");
            }
        }

        [HttpPost("Search Student")]
        public IActionResult SearchStudent([FromBody] StudentMetData studentMetData)
        {
            var student = _students.FirstOrDefault(x =>
                x.StudentMetData?.City == studentMetData.City ||
                x.StudentMetData?.Address == studentMetData.Address ||
                x.StudentMetData?.Phone == studentMetData.Phone);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok("Student found");
        }
    }
}
