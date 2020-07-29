using System.Collections.Generic;

namespace Polymorphic.Models
{
    public class Article
    {
        public Article()
        {
            ArticleComments = new HashSet<ArticleComment>();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }

    }
}