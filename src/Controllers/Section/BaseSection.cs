using System.Collections.Generic;
using TaskManager.Model.Data;
using TaskManager.Model.Repository;

namespace TaskManager.Controllers.Section
{
    public class BaseSection : ISectionFacade
    {
        IRepository _repository;
        public BaseSection(IRepository repository) => _repository = repository;
        public uint CreateColumn(Model.Data.Board board) => _repository.CreateColumn(board);
        public List<Column> GetColumns(Model.Data.Board board) => _repository.GetColumns(board);
        public void UpdateColumn(Column column) => _repository.UpdateColumn(column);
    }
}
