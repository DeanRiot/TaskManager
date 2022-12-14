using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class User
    {
        [Column("Id")]
        public uint UserId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Role Role { get; set; }
        public Auth Auth { get; set; }
    }
}
