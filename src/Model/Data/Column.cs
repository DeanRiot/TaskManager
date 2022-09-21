using System.Collections.Generic;

namespace TaskManager.Model.Data
{
    public class Column
    {
        public string name { get; set; }
        public uint id { get; set; }
        public List<Task> tasks { get; set; }
    }
}
