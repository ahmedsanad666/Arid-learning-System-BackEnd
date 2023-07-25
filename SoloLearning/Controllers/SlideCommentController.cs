using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloLearning.Data;
using SoloLearning.Migrations;
using SoloLearning.Models;

namespace SoloLearning.Controllers
{
  
        [Route("Arid/[controller]")]
        [ApiController]
        public class SlideCommentController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public SlideCommentController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Lessons
            [HttpGet]
            public async Task<ActionResult<IEnumerable<SlideComment>>> GetComments()
            {
                List<SlideComment> allComments = await _context.slideComments.ToListAsync();

             int Count = await _context.slideComments.CountAsync();

            var commnetsData =new
            {
                allComments,
                Count
            };
          

                return Ok(commnetsData);
            }

            // GET: api/Lessons/5
            //[HttpGet("{id}")]
            //public async Task<ActionResult<Lesson>> GetLesson(int id)
            //{
            //    var lesson = await _context.Lessons.FindAsync(id);

            //    if (lesson == null)
            //    {
            //        return NotFound();
            //    }

            //    return lesson;
            //}


            // PUT: api/Lessons/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutComment(int id, SlideComment comment)
            {
                if (id != comment.Id)
                {
                    return BadRequest();
                }

                _context.Entry(comment).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!commentExists(id))
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
            public async Task<ActionResult<SlideComment>> PostComment([FromBody] SlideComment  comment)
            {

            
                    _context.slideComments.Add(comment);

                


                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLesson", new { id = comment.Id }, comment);
            }


            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteComment(int id)
            {
                var comment = await _context.slideComments.FindAsync(id);
                if (comment == null)
                {
                    return NotFound();
                }

                _context.slideComments.Remove(comment);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool commentExists(int id)
            {
                return _context.slideComments.Any(e => e.Id == id);
            }
        }
    
}
