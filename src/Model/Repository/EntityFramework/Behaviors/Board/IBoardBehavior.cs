using System.Collections.Generic;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Board
{
    public interface IBoardBehavior
    {
        uint CreateBoard(Data.Board board);
        List<Data.Board> GetBoard(uint? id = null);
        void UpdateBoard(Data.Board board);
    }
}
