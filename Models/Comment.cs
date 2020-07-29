namespace Polymorphic.Models
{
    public enum CommentType
    {
        Article,
        Video,
        Event
    }

    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
        public int? TypeId { get; set; }
        public CommentType CommentType { get; set; }
    }
}