using System.Collections.Generic;
using TaskManager.Model.Data;

namespace TaskManager.Model.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// create new user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user id if ok</returns>
        uint CreateUser(User user);
        
        /// <summary>
        /// create new board in database
        /// </summary>
        /// <param name="board"></param>
        /// <returns>board id if ok</returns>
        uint CreateBoard(Board board);
        
        /// <summary>
        /// create new column in database
        /// </summary>
        /// <param name="board"></param>
        /// <returns>column id if ok</returns>
        uint CreateColumn(Board board);

        /// <summary>
        /// create new task in database
        /// </summary>
        /// <param name="column"></param>
        /// <returns>task id if ok</returns>
        uint CreateTask(Data.Column column, string token);

        /// <summary>
        /// create comment in selected task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        uint CreateComment(Data.Task task, string token);

        /// <summary>
        /// return board data
        /// </summary>
        /// <param name="board">if null return all boards to preview</param>
        /// <returns></returns>
        List<Board> GetBoard(uint? id = null);

        /// <summary>
        /// return all data of board
        /// </summary>
        /// <param name="board">board to returnable data</param>
        /// <returns></returns>
        List<Column> GetColumns(Board board);
        
        /// <summary>
        /// return users data 
        /// </summary>
        /// <param name="separator">if null return all</param>
        /// <returns></returns>
        List<User> GetUsers(uint? id = null);
        
        /// <summary>
        /// return token by auth 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string Auth(User user);
        
        /// <summary>
        /// update board name and description
        /// </summary>
        /// <param name="board"></param>
        void UpdateBoard(Board board);
        /// <summary>
        /// update all column state
        /// </summary>
        /// <param name="column"></param>
        void UpdateColumn(Column column);
        void UpdateUser(User user);
        
        /// <summary>
        /// check token exists in database
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool HasToken(string token);
    }
}
