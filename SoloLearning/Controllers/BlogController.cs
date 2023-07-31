using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoloLearning.Data;
using SoloLearning.Models;
using System.Net;

namespace SoloLearning.Controllers
{

        [Route("Arid/[controller]")]
        [ApiController]
        public class BlogController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _webHostEnvironment;
            public BlogController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
            {
            _webHostEnvironment = webHostEnvironment;
                _context = context;
            }

            // GET: api/Courses
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Blog>>> AllBlogs()
            {

            var all =  await _context.blogs.Include(w => w.ApiUser).ToListAsync();
         foreach (var blog in all)
            {
                string fileName = "imgs" + blog.Id + ".png";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "imgs", fileName);

                blog.ImgByte = System.IO.File.ReadAllBytes(path);
            }
            return  all;
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

            string fileName = "imgs" + Blog.Id + ".png";
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "imgs",fileName);

            Blog.ImgByte = System.IO.File.ReadAllBytes(path);

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
            public async Task<ActionResult<Blog>> PostUserCourse([FromForm] Blog Blog)
            {

            try
            {

                string message = "";
                var files = Blog.Files;
                Blog.Files = null;

                _context.blogs.Add(Blog);
                await _context.SaveChangesAsync();

                if(Blog.Id > 0 && files != null && files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\imgs\\";
                  
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = "imgs" + Blog.Id + ".png";
                    if(System.IO.File.Exists(path + fileName))
                    {
                        System.IO.File.Delete(path + fileName);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileName)) 
                    {
                    files.CopyTo(fileStream);
                        fileStream.Flush();
                        message = "Success";

                    }
                        

                }else if(Blog.Id == 0){
                    message = "Failed";
                }

                else
                {
                    message = "Success";
                }

                if (message == "Success")
                {
                    return CreatedAtAction("GetBlog", new { id = Blog.Id }, Blog);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, message);
                }
              

            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
               
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

