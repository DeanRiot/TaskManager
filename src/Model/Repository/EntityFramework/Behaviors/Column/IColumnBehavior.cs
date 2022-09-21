using System.Collections.Generic;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Column
{
    public interface IColumnBehavior
    {
        uint CreateColumn(Data.Board board);
        void UpdateColumn(Data.Column column);
        List<Data.Column> GetColumns(Data.Board board);
    }
}
