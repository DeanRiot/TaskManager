using System.Collections.Generic;
using TaskManager.Model.Output;

namespace TaskManager.Model.Repository.EntityFramework
{
    public class EntityFrameworkRepository : IRepository
    {
        public int CreateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public int CreateColumn(Board board)
        {
            throw new System.NotImplementedException();
        }

        public int CreateComment(Task task)
        {
            throw new System.NotImplementedException();
        }

        public int CreateTask(Column column)
        {
            throw new System.NotImplementedException();
        }

        public int CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetAuth(User user)
        {
            throw new System.NotImplementedException();
        }

        public List<Board> GetBoard(Board board = null)
        {
            throw new System.NotImplementedException();
        }

        public List<Column> GetColumns(Board board)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUsers(User separator = null)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBoard(Board board)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateColumn(Column column)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
