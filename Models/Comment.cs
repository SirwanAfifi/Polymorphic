using System.Collections.Generic;

namespace Polymorphic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
        
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
        public virtual ICollection<VideoComment> VideoComments { get; set; }
        public virtual ICollection<EventComment> EventComments { get; set; }
    }
}