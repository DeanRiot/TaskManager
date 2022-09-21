using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Model.Repository.EntityFramework.Context;

namespace TaskManager.Model.Repository.EntityFramework.Behaviors.Board
{
    public class BoardBehavior : IBoardBehavior
    {
        DbContextOptions _options;
        public BoardBehavior(DbContextOptions options) => _options = options;
        public uint CreateBoard(Data.Board board)
        {
            using (TaskmanContext context = new(_options))
            {
                var date = DateTime.Now;
                AddBoard(board, context);
                context.SaveChanges();
                return GetBoardId(board, context, date);
            }
        }
        private static void AddBoard(Data.Board board, TaskmanContext context)
        {
            context.Board.Add(new Context.Board()
            {
                Name = board.name,
                Creation = DateTime.Now,
                Color = board.color,
            });
        }

        private uint GetBoardId(Data.Board board, TaskmanContext context, DateTime date)
        {
            return context.Board
                   .Where(b => b.Name.Equals(board.name))
                   .Where(b => b.Creation.Equals(date))
                   .Select(b => b.BoardId)
                   .Single();
        }

        public List<Data.Board> GetBoard(uint? id= null)
        {
            using (TaskmanContext context = new(_options))
                return id is null ? GetAll(context) : GetOne(context,(uint) id);
        }

        private List<Data.Board> GetOne(TaskmanContext context,uint id) =>
                                ToBoardsList(FindById(context, id));

        private List<Data.Board> GetAll(TaskmanContext context) =>
                 context.Board.Select(b => new Data.Board(b.BoardId, b.Name, b.Description, b.Color))
                .ToList();

        public void UpdateBoard(Data.Board board)
        {
            using (TaskmanContext context = new(_options))
            {
                var finded_board = (Context.Board)FindById(context, board.id).Select(b => b);
                finded_board = UpdateActions(board, finded_board);
                context.Update(finded_board);
                context.SaveChanges();
            }
        }

        private Context.Board UpdateActions(Data.Board board, Context.Board finded_board)
        {
            if (board.name is not null) finded_board.Name = board.name;
            if (board.description is not null) finded_board.Description = board.description;
            if (board.color is not null) finded_board.Color = board.color;
            return finded_board;
        }

        private static IQueryable<Context.Board> FindById(TaskmanContext context,uint id) =>
                                                  context.Board.Where(b => b.BoardId.Equals(id));
        private List<Data.Board> ToBoardsList(IQueryable<Context.Board> boards) =>
            boards.Select(b => new Data.Board(b.BoardId, b.Name, b.Description, b.Color))
                .ToList();
    }
}
