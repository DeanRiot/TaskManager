using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.User
{
    public class UserBehavior:IUserBehavior
    {
        DbContextOptions _options;
        public UserBehavior(DbContextOptions options) => _options = options;

        public string Auth(Data.User user)
        {
            throw new System.NotImplementedException();
        }

        public uint CreateUser(Data.User user)
        {
            throw new System.NotImplementedException();
        }

        public Context.User GetUser(string token)
        {
            throw new System.NotImplementedException();
        }

        public List<Data.User> GetUsers(uint? id = null)
        {
            throw new System.NotImplementedException();
        }

        public bool HasToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(Data.User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
