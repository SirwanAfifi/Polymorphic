using System.Collections.Generic;

namespace Polymorphic.Models
{
    public class Video
    {
        public Video()
        {
            VideoComments = new HashSet<VideoComment>();
        }
        
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<VideoComment> VideoComments { get; set; }
    }
}