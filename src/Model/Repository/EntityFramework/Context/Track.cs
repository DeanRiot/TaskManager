using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Track
    {
        [Column("Id")]
        public uint TrackId { get; set; }
        public DateTime Date { get; set; }
        public string Opertion {get; set; }
        public virtual User User { get; set; }
        public virtual Task Task { get; set; }
    }
}
