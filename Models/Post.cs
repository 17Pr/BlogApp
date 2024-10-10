using System;
using System.Collections.Generic;

namespace BlogApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation Property
        public List<Comment> Comments { get; set; }
    }
}
