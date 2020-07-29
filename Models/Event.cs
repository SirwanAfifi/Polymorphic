using System;
namespace Polymorphic.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
    }
}