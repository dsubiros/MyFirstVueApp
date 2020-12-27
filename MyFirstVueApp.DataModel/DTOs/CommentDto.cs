using System;
using MyFirstVueApp.Database.Models;

#nullable disable

namespace MyFirstVueApp.Database.DTOs
{
    public partial class CommentDto
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }
        public int PostId { get; set; }

        // public virtual PostDto Post { get; set; }
    }
}
