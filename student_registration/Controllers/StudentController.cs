using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Application.Interfaces;
using StudentRegistration.Domain.Entities;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace student_registration.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Student student)
        {
            if(student == null)
            {
                return BadRequest("enter valid student details");
            }

            var isSuccess = await _studentService.RegisterStudentAsync(student);
            if (isSuccess)
            {
                return Ok(student);
            }
            return BadRequest("could not register the student ");

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetActiveStudentsAsync();

            return Ok(students);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeleted = await _studentService.DeleteStudentAsync(id);
            if (isDeleted)
            {
                return Ok(new { message = $"user id{id} soft deleted" });       
             }

            return NotFound($"user id {id} not found ");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Student student)
        {

            if (id != student.Id)
            {
                return BadRequest($"id{id} is mismatch");
            }
            var isUpdated = await _studentService.UpdateStudentAsync(student);
            if(isUpdated)
            {
                return Ok(new { message = $"user {id} updated" });
            }

            return NotFound("update unsuccess");
        }


    }
}
