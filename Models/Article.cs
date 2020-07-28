using System.Collections.Generic;

namespace Polymorphic.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
    }
}