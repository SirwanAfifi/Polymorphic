namespace Polymorphic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
        
        // Article
        public virtual Article Article { get; set; }
        public int? ArticleId { get; set; }
    
        // Video
        public virtual Video Video { get; set; }
        public int? VideoId { get; set; }
    
        // Event
        public virtual Event Event { get; set; }
        public int? EventId { get; set; }
    }
}