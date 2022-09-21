using System.Collections.Generic;
using TaskManager.Model.Data;

namespace TaskManager.Controllers.Account
{
    public interface IAccountFacade
    {
        public uint Create(User user);
        public IEnumerable<User> Read(uint? id = null);
        public void Update(User user);
        /// <summary>
        /// return token or null
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Auth(User user);
        public bool HasToken(string token);
    }
}
