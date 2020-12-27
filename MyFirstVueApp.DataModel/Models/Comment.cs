using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstVueApp.Database.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
