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
            //
            //Name              : BoardRepo(BoardContext context)
            //Purpose           : Overloaded constructor that receives the database context 
            //                    through dependency injection
            //Re-use            : none
            //Method Parameters : BoardContext context                    
            //Output Type       : none
            //
            _context = context;
        }

        public IEnumerable<Board> GetBoards()
        {
            //
            //Name              : IEnumerable<Board> GetBoards()
            //Purpose           : Retrieves a collection of all Board entities from the repository
            //Re-use            : none
            //Method Parameters : none
            //Output Type       : IEnumerable<Board>            
            //
            return _context.Boards.ToList();
        }

        public Board Details(string boardCode)
        {
            //
            //Name              : Board Details(string boardCode)
            //Purpose           : Retrieves details of a specific board based on its unique board code
            //Re-use            : none
            //Method Parameters : string boardCode
            //Output Type       : Board
            //                    the matching Board object
            //
            return _context.Boards.FirstOrDefault(b => b.BoardCode == boardCode);
        }

        public Board Create(Board board)
        {
            //
            //Name              : Board Create(Board board)
            //Purpose           : Creates and persists a new board entry in the repository
            //Re-use            : none
            //Method Parameters : Board board
            //Output Type       : Board            
            //
            _context.Boards.Add(board);
            _context.SaveChanges();
            return board;
        }

        public Board Edit(Board board)
        {
            //
            //Name              : Board Edit(Board board)
            //Purpose           : Updates an existing board entry in the repository
            //Re-use            : none
            //Method Parameters : Board board
            //Output Type       : Board
            //
            _context.Boards.Update(board);
            _context.SaveChanges();
            return board;
        }

        public bool Delete(Board board)
        {
            //
            //Name              : bool Delete(Board board)
            //Purpose           : Deletes an existing board entry from the repository
            //Re-use            : none
            //Method Parameters : Board board
            //Output Type       : bool
            //
            _context.Boards.Remove(board);
            int trackingRows = _context.SaveChanges();
            return trackingRows > 0;
        }

        public bool IsExist(string boardCode)
        {
            //
            //Name              : bool IsExist(string boardCode)
            //Purpose           : Checks if a board with the specified board code exists in the repository
            //Re-use            : none
            //Method Parameters : string boardCode
            //Output Type       : bool
            //
            return _context.Boards.Any(b => b.BoardCode == boardCode);
        }
    }
}
