using System;
using System.Collections.Generic;

namespace Polymorphic.Models
{
    public class Event
    {
        public Event()
        {
            EventComments = new HashSet<EventComment>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
        
        public virtual ICollection<EventComment> EventComments { get; set; }
    }
}