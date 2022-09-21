using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Token
    {
        [Column("Id")]
        public int TokenId { get; set; }
        public string Data { get; set; }
        public uint UserId { get; set; }
        public User User { get; set; }
    }
}
