using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Task
    {
        [Column("Id")]
        public uint TaskId { get; set; }
        public string Text { get; set; }
        public DateTime Deadline { get; set; }
        public Status Status { get; set; }
        public uint SectionID { get; set; }
        public Section Section { get; set; }
        public uint TrackId { get; set; }
        public Track Track { get; set; }
        public List<User> responsibility { get; set; }

    }
}
