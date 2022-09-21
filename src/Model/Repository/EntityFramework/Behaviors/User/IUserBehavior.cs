using System.Collections.Generic;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.User
{
    public interface IUserBehavior
    {
        Context.User GetUser(string token);
        string Auth(Data.User user);
        uint CreateUser(Data.User user);
        List<Data.User> GetUsers(uint? id = null);
        void UpdateUser(Data.User user);
        bool HasToken(string token);
    }
}
