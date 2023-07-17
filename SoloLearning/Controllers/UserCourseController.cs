using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloLearning.Data;
using SoloLearning.Models;

namespace SoloLearning.Controllers
{
    [Route("Arid/[controller]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserCourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourse>>> GetUserCourses()
        {
            return await _context.UserCourses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCourse>> GetUserCourse(int id)
        {
            var course = await _context.UserCourses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCourse(int id, UserCourse  UserCourse)
        {
            if (id != UserCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(UserCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCourse>> PostUserCourse(UserCourse userCourse)
        {
            _context.UserCourses.Add(userCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = userCourse.Id }, userCourse);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCourse(int id)
        {
            var course = await _context.UserCourses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.UserCourses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCourseExists(int id)
        {
            return _context.UserCourses.Any(e => e.Id == id);
        }
    }
}
