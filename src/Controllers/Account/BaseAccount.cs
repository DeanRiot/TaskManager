using System.Collections.Generic;
using TaskManager.Model.Data;
using TaskManager.Model.Repository;

namespace TaskManager.Controllers.Account
{
    public class BaseAccount : IAccountFacade
    {
        IRepository _repository;
        public BaseAccount(IRepository repository) => _repository = repository;
        public uint Create(User user) => _repository.CreateUser(user);
        public IEnumerable<User> Read(uint? id = null) => _repository.GetUsers(id);
        public void Update(User user) => _repository.UpdateUser(user); 
        public string Auth(User user) => _repository.Auth(user);

        public bool HasToken(string token) => _repository.HasToken(token);
    }
}
