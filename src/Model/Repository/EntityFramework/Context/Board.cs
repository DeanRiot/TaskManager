using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Board
    {
        [Column("Id")]
        public uint BoardId{ get; set; }
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public List<Section> Sections { get; set; }
    }
}
