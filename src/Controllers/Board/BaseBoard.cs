using System.Collections.Generic;
using TaskManager.Model.Repository;

namespace TaskManager.Controllers.Board
{
    public class BaseBoard : IBoardFacade
    {
        IRepository _repository;
        public BaseBoard(IRepository repository) => _repository = repository;

        public uint? Create(Model.Data.Board board) => _repository.CreateBoard(board);
        public List<Model.Data.Board> Get(uint? id = null) => _repository.GetBoard(id);
        public void Update(Model.Data.Board board) => _repository.UpdateBoard(board);
    }
}
