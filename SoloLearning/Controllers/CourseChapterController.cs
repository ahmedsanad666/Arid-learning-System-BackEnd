using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloLearning.Data;
using SoloLearning.Models;

namespace SoloLearning.Controllers
{
    [Route("Arid/[controller]")]
    [ApiController]
    public class CourseChapterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseChapterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CourseCourseChapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseChapter>>> GetCourseChapters()
        {
                var chapters= await _context.CourseChapters.Include(e => e.Course).ToListAsync();
            return chapters;    
        }

        // GET: api/CourseCourseChapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseChapter>> GetCourseChapter(int id)
        {
            var courseChapter = await _context.CourseChapters.FindAsync(id);

            if (courseChapter == null)
            {
                return NotFound();
            }

            return courseChapter;
        }

        // PUT: api/CourseCourseChapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseChapter(int id, CourseChapter courseChapter)
        {
            if (id != courseChapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseChapter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseChapterExists(id))
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

        // POST: api/CourseCourseChapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseChapter>> PostCourseChapter(CourseChapter courseChapter)
        {
            _context.CourseChapters.Add(courseChapter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseChapter", new { id = courseChapter.Id }, courseChapter);
        }

        // DELETE: api/CourseCourseChapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseChapter(int id)
        {
            var courseChapter = await _context.CourseChapters.FindAsync(id);
            if (courseChapter == null)
            {
                return NotFound();
            }

            _context.CourseChapters.Remove(courseChapter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseChapterExists(int id)
        {
            return _context.CourseChapters.Any(e => e.Id == id);
        }
    }
}
