namespace Polymorphic.Models
{
    public class ArticleComment
    {
        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }

        public virtual Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
    public class VideoComment
    {
        public virtual Video Video { get; set; }
        public int VideoId { get; set; }

        public virtual Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
    public class EventComment
    {
        public virtual Event Event { get; set; }
        public int EventId { get; set; }

        public virtual Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}