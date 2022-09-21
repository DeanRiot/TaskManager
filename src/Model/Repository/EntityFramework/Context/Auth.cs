using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.Repository.EntityFramework.Context
{
    public class Auth
    {
        [Column("Id")]
        public uint AuthId { get; set; }
        public string login { get; set; }
        public string Password { get; set; }
        public uint UserId { get; set; }
        public User User { get; set; }
        public List<Token> Token { get; set; }
    }
}
