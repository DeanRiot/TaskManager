using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Responsibility
    {
        [Column("Id")]
        public uint ResponsibilityId { get; set; }
        public List<Task> Task { get; set; }
        public List<User> User { get; set; }
    }
}
