using System;
using System.Collections.Generic;
using MyFirstVueApp.Database.Models;

#nullable disable

namespace MyFirstVueApp.Database.DTOs
{
    public partial class PostDto
    {
        public int PostId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }
        public int BlogId { get; set; }

        // public virtual BlogDto Blog { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
    }
}
