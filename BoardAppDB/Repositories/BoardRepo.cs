// Group leader name : Kabelo Nhlapo
// Group Student nrs : 224042163; 220048471; 219005935; 224136508; 224069913; 223068452; 224037409
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this file is to serve as the application entry point,
//                     registering the required services (MVC and the BoardContext database
//                     context) and configuring the HTTP request pipeline and routing.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext _context;

        public BoardRepo(BoardContext context)
        {
            _context = context;
        }

        public IEnumerable<Board> GetBoards()
        {
            return _context.Boards.ToList();
        }

        public Board Details(string boardCode)
        {
            return _context.Boards.FirstOrDefault(b => b.BoardCode == boardCode);
        }

        public Board Create(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
            return board;
        }

        public Board Edit(Board board)
        {
            _context.Boards.Update(board);
            _context.SaveChanges();
            return board;
        }

        public bool Delete(Board board)
        {
            _context.Boards.Remove(board);
            int trackingRows = _context.SaveChanges();
            return trackingRows > 0;
        }

        public bool IsExist(string boardCode)
        {
            return _context.Boards.Any(b => b.BoardCode == boardCode);
        }
    }
}
