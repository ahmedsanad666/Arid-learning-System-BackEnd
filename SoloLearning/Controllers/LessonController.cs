using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SoloLearning.Data;
using SoloLearning.Models;

namespace SoloLearning.Controllers
{
    [Route("Arid/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Lessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
        {
            List<Lesson> LessonData = await _context.Lessons.Include(e=> e.CourseChapter).ToListAsync();
            List<Slide> Slides = await _context.Slides.ToListAsync();
            List<Question> questions = await _context.Question.ToListAsync();


            var combinedData = new
            {
              LessonData,
             Slides,
               questions
            };

            return Ok(combinedData);
        }

        // GET: api/Lessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lesson>> GetLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }

            return lesson;
        }


        // PUT: api/Lessons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
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

        // POST: api/Lessons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Lesson>> PostLesson([FromBody] Lesson lesson)
        {

            if ( lesson.Slides != null)
            {


            lesson.Slides.ForEach(slide =>
            {

                _context.Slides.Add(slide);

                foreach (var q in slide.Questions)
                {
                    _context.Question.Add(q);
                }
            });
            }
            else
            {   
            _context.Lessons.Add(lesson);

            }

            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLesson", new { id = lesson.Id }, lesson);
        }


        [HttpPost("AddSlides")]
        [Authorize]
        public async Task<ActionResult<Slide>> PostSlides([FromBody] List<Slide> Slides)
        {

            if (Slides != null)
            {
                    

               Slides.ForEach(slide =>
                {
                    _context.Slides.Add(slide);

                    foreach (var q in slide.Questions)
                    {
                        _context.Question.Add(q);
                    }
                });
            }


            await _context.SaveChangesAsync();

            return CreatedAtAction("GelSlides",  Slides);
        }
        // DELETE: api/Lessons/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Id == id);
        }
    }
}
