using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers;

public class HomeController : Controller
{
    private readonly BlogContext _context;

    public HomeController(BlogContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch posts from the BlogContext
        var posts = _context.Posts.ToList();

        // Ensure posts is not null
        if (posts == null)
        {
            posts = new List<Post>(); // Handle the case where no posts exist
        }

        // Pass the list of posts to the view
        return View(posts);
    }
}
