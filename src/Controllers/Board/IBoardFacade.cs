using System.Collections.Generic;

namespace TaskManager.Controllers.Board
{
    public interface IBoardFacade
    {
        uint? Create(Model.Data.Board board);
        List<Model.Data.Board> Get(uint? id = null);
        void Update(Model.Data.Board board);
    }
}
