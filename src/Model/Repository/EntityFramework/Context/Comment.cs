using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Comment
    {
        [Column("Id")]
        public uint CommentId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime date { get; set; }
        public uint TaskId {get;set;}
        public Task Task { get; set; } 
    }
}
