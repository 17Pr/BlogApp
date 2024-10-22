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

        // GET: Posts
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList(); // Fetch list of posts
            return View(posts); // Pass the collection to the view
        }

        // GET: Posts/Create
        public IActionResult Create()
{
    return View();
}

// POST: Posts/Create
[HttpPost]
public async Task<IActionResult> Create(Post post)
{
    post.CreatedAt = DateTime.Now;
    _context.Add(post);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

        // GET: Posts/Details/5
        public IActionResult Details(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _context.Posts.FirstOrDefault(m => m.PostId == id);
            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);  // Pass the post to the Delete view
        }

        // POST: Posts/Delete/5 (Confirm Deletion)
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

            return RedirectToAction(nameof(Index)); // Redirect to Index after deletion
        }
    }
}
