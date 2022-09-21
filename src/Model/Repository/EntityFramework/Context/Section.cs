using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Section
    {
        [Column("Id")]
        public uint SectionId { get; set; }
        public string Name { get; set; }
        public uint BoardId { get; set; }
        public Board Board { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
