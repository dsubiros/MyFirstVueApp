using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstVueApp.Database.Models
{
    public partial class Todo
    {
        public int TodoId { get; set; }
        public string Text { get; set; }
        public bool? Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Hide { get; set; }
    }
}
