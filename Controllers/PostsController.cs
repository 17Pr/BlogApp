using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogContext _context;
        
        public PostsController(BlogContext context)
        {
            _context = context;
        }

      public IActionResult Index()
{
    var posts = _context.Posts.ToList(); // Returns a list of posts
    return View(posts); // Correctly passing a collection
}



        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
public async Task<IActionResult> Create(Post post)
{
    post.CreatedAt = DateTime.Now;
    _context.Add(post);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

        public IActionResult Details(int id)
{
    var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

    if (post == null)
    {
        return NotFound();
    }

    return View(post);
}
public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
