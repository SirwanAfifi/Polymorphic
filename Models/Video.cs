using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polymorphic.Models
{
    public class Video : ICommentable
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
    }
}