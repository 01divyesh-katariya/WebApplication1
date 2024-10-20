using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDBContext _context;

        // Constructor with Dependency Injection
        public StudentAPIController(MyDBContext context)
        {
            _context = context;  // Assign the injected context to the private field
        }

        // Example of an action method
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await _context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreatStudent(Student std)
        {
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
             _context.Entry(std).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(std);

        }
        [HttpDelete ("{id}")]
        public async Task<ActionResult<Student>> DeleteStuden( int id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            _context.Students.Remove(std);                  
            await _context.SaveChangesAsync();
            return Ok(std);
        }

    }

        
}

