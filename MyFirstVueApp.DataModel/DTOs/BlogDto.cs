using System;
using System.Collections.Generic;
using MyFirstVueApp.Database.Models;

#nullable disable

namespace MyFirstVueApp.Database.DTOs
{
    public partial class BlogDto
    {
        public int BlogId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }

        // public virtual ICollection<PostDto> Posts { get; set; }
    }
}
