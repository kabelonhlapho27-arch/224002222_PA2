// Group leader name : Kabelo Nhlapho
// Group Student nrs : 224042163; 220048471; 219005935; 224136508; 224069913; 223068452; 224037409
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this interface is to define the contract for
//                     data access operations on Board entities in the repository layer.

using System.Collections.Generic;
using BoardAppDB.Models;

namespace BoardAppDB.Interfaces
{
    public interface IBoard
    {
        //
        //Name              : IEnumerable<Board> GetBoards()
        //Purpose           : Retrieves a collection of all Board entities from the repository
        //Re-use            : none
        //Method Parameters : none
        //Output Type       : IEnumerable<Board>
        //                    collection of Board objects
        //
        IEnumerable<Board> GetBoards();

        //
        //Name              : Board Details(string boardCode)
        //Purpose           : Retrieves details of a specific board based on its unique board code
        //Re-use            : none
        //Method Parameters : string boardCode
        //                    the unique board code of the board to retrieve details for
        //Output Type       : Board
        //                    the matching Board object
        //
        Board Details(string boardCode);

        //
        //Name              : Board Create(Board board)
        //Purpose           : Creates and persists a new board entry in the repository
        //Re-use            : none
        //Method Parameters : Board board
        //                    the Board object representing the new board to be created
        //Output Type       : Board
        //                    the created Board object
        //
        Board Create(Board board);

        //
        //Name              : Board Edit(Board board)
        //Purpose           : Updates an existing board entry in the repository
        //Re-use            : none
        //Method Parameters : Board board
        //                    the Board object representing the modified board
        //Output Type       : Board
        //                    the updated Board object
        //
        Board Edit(Board board);

        //
        //Name              : bool Delete(Board board)
        //Purpose           : Deletes an existing board entry from the repository
        //Re-use            : none
        //Method Parameters : Board board
        //                    the Board object representing the board to be deleted
        //Output Type       : bool
        //                    true if the deletion was successful, false otherwise
        //
        bool Delete(Board board);

        //
        //Name              : bool IsExist(string boardCode)
        //Purpose           : Checks if a board with the specified board code exists in the repository
        //Re-use            : none
        //Method Parameters : string boardCode
        //                    the board code to check for existence
        //Output Type       : bool
        //                    true if a board with the given board code exists, false otherwise
        //
        bool IsExist(string boardCode);
    } // end interface IBoard
} // end namespace BoardAppDB.Interfaces
