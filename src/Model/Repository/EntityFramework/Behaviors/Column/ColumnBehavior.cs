using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Model.Repository.EntityFramework.Context;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Column
{
    public class ColumnBehavior:IColumnBehavior
    {
        DbContextOptions _options;
        public ColumnBehavior(DbContextOptions options) => _options = options;

        public uint CreateColumn(Data.Board board)
        {
            var column = board.columns[0];
            using (TaskmanContext context = new(_options))
            {
                context.Section.Add(new Section()
                {
                    BoardId = board.id,
                    Name = board.columns[0].name
                });
                context.SaveChanges();
                return context.Section
                       .Where(s => s.BoardId.Equals(board.id))
                       .Where(s => s.Name.Equals(column.name))
                       .Select(s => s.SectionId)
                       .First();    
            }
        }

        public List<Data.Column> GetColumns(Data.Board board)
        {
            var column = board.columns[0];
            using (TaskmanContext context = new(_options))
            {
                return context.Section
                                .Where(s=>s.BoardId.Equals(board))
                                .Select(s=>new Data.Column()
                                {
                                    id = s.SectionId,
                                    name = s.Name,
                                    tasks = s.Tasks.Select(t=>new Data.Task()
                                    {
                                        id = t.TaskId,
                                        text = t.Text,
                                        //responisbility = 
                                        //comments = 
                                        deadline = t.Deadline.ToShortDateString()
                                    }).ToList()
                                }).ToList();
            }   
        }

        public void UpdateColumn(Data.Column column)
        {
            using (TaskmanContext context = new(_options))
            {
                context.Section.Update(GetColumnData(context,column));
                context.SaveChanges();
            }
        }

        private Section GetColumnData(TaskmanContext context, Data.Column column)
        {
            var finded = Find(context, column.id);
            if (column.name is not null) finded.Name = column.name;
            return finded;
        }

        private Section Find(TaskmanContext context, uint id)=>
                (Section)context.Section.Where(s=>s.SectionId.Equals(id))
                                .Select(x=>x);
        
    }
}
