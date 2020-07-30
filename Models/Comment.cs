using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polymorphic.Models
{

    public interface ICommentable
    {
        int Id { get; set; }
    }

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

        ICommentable _parent;

        [NotMapped]
        public ICommentable Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                TypeId = value.Id;
                CommentType = (CommentType) Enum.Parse(typeof(CommentType), value.GetType().Name);
            }
        }
    }
}