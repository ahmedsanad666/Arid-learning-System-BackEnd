using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloLearning.Data;
using SoloLearning.Models;

namespace SoloLearning.Controllers
{

        [Route("Arid/[controller]")]
        [ApiController]
        public class BlogController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public BlogController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: api/Courses
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Blog>>> AllBlogs()
            {


                return await _context.blogs.Include(w => w.ApiUser).ToListAsync();
            }

            // GET: api/Courses/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Blog>> SingleBlog(int id)
            {
                var Blog = await _context.blogs.FindAsync(id);

                if (Blog == null)
                {
                    return NotFound();
                }

                return Blog;
            }

            // PUT: api/Courses/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> AddBlog(int id, Blog Blog)
            {
                if (id != Blog.Id)
                {
                    return BadRequest();
                }

                _context.Entry(Blog).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(id))
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
            public async Task<ActionResult<Blog>> PostUserCourse(Blog Blog)
            {
                _context.blogs.Add(Blog);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBlog", new { id = Blog.Id }, Blog);
            }

            // DELETE: api/Courses/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUserCourse(int id)
            {
                var Blog = await _context.blogs.FindAsync(id);
                if (Blog == null)
                {
                    return NotFound();
                }

                _context.blogs.Remove(Blog);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool BlogExists(int id)
            {
                return _context.blogs.Any(e => e.Id == id);
            }
        }
    }

