using System.Collections.Generic;

namespace TaskManager.Model.Output
{
    public class Task
    {
        public uint id { get; set; }
        public string text { get; set; }
        public string deadline { get; set; }
        public List<Event> events { get; set; }
        public List<User> responisbility { get; set; }
        public List<Comment> comments { get; set; }
    }
}
