using System.Collections.Generic;

namespace TaskManager.Controllers.Section
{
    public interface ISectionFacade
    {
        uint CreateColumn(Model.Data.Board board);
        List<Model.Data.Column> GetColumns(Model.Data.Board board);
        void UpdateColumn(Model.Data.Column column);
    }
}
