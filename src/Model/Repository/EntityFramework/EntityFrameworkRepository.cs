using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManager.Model.Data;
using TaskManager.Model.Repository.EntityFramework.Behaviors.Board;
using TaskManager.Model.Repository.EntityFramework.Behaviors.Column;
using TaskManager.Model.Repository.EntityFramework.Behaviors.Task;
using TaskManager.Model.Repository.EntityFramework.Behaviors.User;

namespace TaskManager.Model.Repository.EntityFramework
{
    public class EntityFrameworkRepository : IRepository
    {
        IBoardBehavior _boardBehavior;
        IColumnBehavior _columnBehavior;
        IUserBehavior _userBehavior;
        ITaskBahavior _taskBahavior;
        
        public EntityFrameworkRepository(DbContextOptions options)
        {
            _boardBehavior = new BoardBehavior(options);
            _columnBehavior = new ColumnBehavior(options);
            _userBehavior = new UserBehavior(options);
            _taskBahavior = new TaskBehavior(options);
        }
        public uint CreateBoard(Data.Board board)=> _boardBehavior.CreateBoard(board);
        public List<Data.Board> GetBoard(uint? id = null) => _boardBehavior.GetBoard(id);
        public void UpdateBoard(Data.Board board) => _boardBehavior.UpdateBoard(board);
        
        public uint CreateColumn(Data.Board board) => _columnBehavior.CreateColumn(board);
        public List<Column> GetColumns(Data.Board board) => _columnBehavior.GetColumns(board);
        public void UpdateColumn(Data.Column column) => _columnBehavior.UpdateColumn(column);

        public uint CreateTask(Data.Column column,string token)
        {
             var user = _userBehavior.GetUser(token);
            return _taskBahavior.CreateTask(column,user);
        } 
        public void UpdateTask(Data.Column column, string token)
        {
            var user = _userBehavior.GetUser(token);
            _taskBahavior.UpdateTask(column,user);
        } 

        public uint CreateComment(Data.Task task, string token)
        {
            var user = _userBehavior.GetUser(token);
            List<Data.Task> t = new();
            t.Add(task);
            return _taskBahavior.UpdateTask(new Column() { tasks = t},user); 
        }
         

        public string Auth(Data.User user)
        {
            throw new System.NotImplementedException();
        }

        public uint CreateUser(Data.User user)
        {
            throw new System.NotImplementedException();
        }

        public List<Data.User> GetUsers(uint? id = null)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(Data.User user)
        {
            throw new System.NotImplementedException();
        }

        public bool HasToken(string token)
        {
            var user = _userBehavior.GetUser(token);
            return user != null;
        }
    }
}
