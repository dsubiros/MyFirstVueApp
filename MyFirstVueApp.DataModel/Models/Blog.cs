using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstVueApp.Database.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
