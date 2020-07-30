using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polymorphic.Models
{
    public class Article : ICommentable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
    }
}