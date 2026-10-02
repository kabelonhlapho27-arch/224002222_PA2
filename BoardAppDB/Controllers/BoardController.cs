// Group leader name : Kabelo Nhlapho
// Group Student nrs :  224042163; 220048471; 219005935; 224136508; 224069913; 223068452; 224037409
// Assignment nr     : SOD226C Practical Assessment 2 Â· 2026
// Purpose           : The purpose of this class is to act as the controller for the
//                     home, privacy and error pages of the Board App.

using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        // Private field for dependency injection
        private readonly IBoard _boardRepo;

        public BoardController(IBoard boardRepo)
        {
            //
            //Name              : BoardController(IBoard boardRepo)
            //Purpose           : Overloaded constructor that receives the board repository 
            //                    service through dependency injection
            //Re-use            : none
            //Method Parameters : IBoard boardRepo
            //                    the repository instance used to interact with the database
            //Output Type       : none

            _boardRepo = boardRepo;
        } // end Constructor

        public IActionResult Index()
        {
            //
            //Name              : Index()
            //Purpose           : Handles the primary dashboard view action, retrieving 
            //                    and passing the list of all boards from the database
            //Re-use            : IBoard.GetBoards()
            //Method Parameters : none
            //Output Type       : IActionResult
            //                    returns the Index view containing the collection data array
            //
            return View(_boardRepo.GetBoards());
        }// end method
        public IActionResult Details(string boardCode)
        {
            //
            //Name              : Details(string boardCode)
            //Purpose           : Fetches the read-only technical metrics matching a unique primary key
            //Re-use            : IBoard.Details(string boardCode)
            //Method Parameters : string boardCode
            //                    the unique primary identifier text string of the target record
            //Output Type       : IActionResult
            //                    returns the Details layout view filled with the entity data model
            //
            Board targetBoard = _boardRepo.Details(boardCode);

            return View(targetBoard);
        }// end method
        [HttpGet]
        public IActionResult Create()
        {
            //
            //Name              : Create()
            //Purpose           : Action handler rendering an empty creation interface dashboard form
            //Re-use            : none
            //Method Parameters : none
            //Output Type       : IActionResult
            //                    returns the empty default view with the submission button visibility flag enabled
            //
            ViewBag.ShowAdd = true;

            return View();
        }// end method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            //
            //Name              : Create(Board board)
            //Purpose           : Validates and saves newly captured entries into the persistent SQLite context table
            //Re-use            : IBoard.IsExist(string boardCode), IBoard.Create(Board board)
            //Method Parameters : Board board
            //                    the target data object parsed and model-bound out of form input entries
            //Output Type       : IActionResult
            //                    returns the form context with an alert message on success, or validation notifications on failure
            //
            if (_boardRepo.IsExist(board.BoardCode))
            {
                ModelState.AddModelError("BoardCode", "A board with that board code already exists.");
            }

            // Check whether there have been any validation problems.
            if (ModelState.IsValid)
            {
                _boardRepo.Create(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was added.";
                ViewBag.ShowAdd = false;
            }
            else
            {
                ViewBag.ShowAdd = true;
            }
            return View(board);
        }// end method
        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            //
            //Name              : Edit(string boardCode)
            //Purpose           : Populates an entity's fields inside an interactive update container profile form
            //Re-use            : IBoard.Details(string boardCode)
            //Method Parameters : string boardCode
            //                    the targeted primary key mapping identifier of the row context being updated
            //Output Type       : IActionResult
            //                    returns the populated default form view with modification action toggles enabled
            //
            Board targetBoard = _boardRepo.Details(boardCode);

            // ViewBag.ShowSave must also be updated accordingly to make the Save button visible.
            ViewBag.ShowSave = true;

            // This object must then be returned with the default view.
            return View(targetBoard);
        }// end method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode, [Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            //
            //Name              : Edit(string boardCode, Board board)
            //Purpose           : Saves user-updated text changes securely back into persistent database structures
            //Re-use            : IBoard.Edit(Board board)
            //Method Parameters : string boardCode
            //                    the context string identifier parameter mapping key of the data row
            //                    Board board
            //                    the bound container model carrying the updated user modifications
            //Output Type       : IActionResult
            //                    returns the modification default form view indicating operation state status text
            //
            if (ModelState.IsValid)
            {
                _boardRepo.Edit(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was updated.";
                ViewBag.ShowSave = false;
            }
            else
            {
                ViewBag.ShowSave = true;
            }
            return View(board);
        }// end method
        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            //
            //Name              : Delete(string boardCode)
            //Purpose           : Pre-loads target row contexts onto an entity exclusion cancellation interface page
            //Re-use            : IBoard.Details(string boardCode)
            //Method Parameters : string boardCode
            //                    the specific item key string targeted for database record tracking drops
            //Output Type       : IActionResult
            //                    returns the read-only verification view dashboard along with removal operation button states
            //
            Board targetBoard = _boardRepo.Details(boardCode);
            ViewBag.ShowDelete = true;

            return View(targetBoard);
        }// end method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            //
            //Name              : Delete(string boardCode, Board board)
            //Purpose           : Finalizes physical item extraction dropped lines out of database storage sets
            //Re-use            : IBoard.Details(string boardCode), IBoard.Delete(Board board)
            //Method Parameters : string boardCode
            //                    the tracking parameter string used to locate the verified database index path row
            //                    Board board
            //                    the model context metadata container item passed out of request payloads
            //Output Type       : IActionResult
            //                    returns the finalized data verification structure containing success alerts
            //
            Board verifiedBoard = _boardRepo.Details(boardCode);

            if (verifiedBoard != null)
            {
                _boardRepo.Delete(verifiedBoard);
                ViewBag.SuccessMessage = $"Board {boardCode} was deleted.";
                ViewBag.ShowDelete = false;
            }
            else
            {
                ViewBag.ShowDelete = true;
            }

            return View(verifiedBoard);
        }// end method
    }// end BoardController
}// end namespace
