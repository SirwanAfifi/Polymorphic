using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polymorphic.Models
{
    public class Event : ICommentable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
        
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
    }
}