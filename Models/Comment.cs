using System;

namespace BlogApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CommentedAt { get; set; }
        
        // Foreign Key
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
