using System.Collections.Generic;

namespace TaskManager.Model.Output
{
    public class Board
    {
        public Board (uint id, string name, string description, string color)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.color = color;
        }
        public uint id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public List<Column> columns { get; set; }
    }
}
