// Group leader name : Kabelo Nhlapho
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this class is to act as the controller for the
//                     home, privacy and error pages of the Board App.

using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardAppDB.Controllers
{
    public class HomeController : Controller
    {
        // logger received through constructor injection
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //
            //Name             : HomeController(ILogger<HomeController> logger)
            //Purpose          : Overloaded constructor that receives the logger through
            //                   dependency injection
            //Re-use           : None
            //Method Parameters: ILogger<HomeController> logger
            //                   logger used by this controller
            //Output Type      : None
            //
            _logger = logger;
        } // end method

        public IActionResult Index()
        {
            //
            //Name             : IActionResult Index()
            //Purpose          : Returns the default view for the home page
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : IActionResult
            //                   the Index view
            //
            return View();
        } // end method

        public IActionResult Privacy()
        {
            //
            //Name             : IActionResult Privacy()
            //Purpose          : Returns the default view for the privacy page
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : IActionResult
            //                   the Privacy view
            //
            return View();
        } // end method

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //
            //Name             : IActionResult Error()
            //Purpose          : Returns the error view with the ID of the request that failed
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : IActionResult
            //                   the Error view with an ErrorViewModel object
            //
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } // end method
    } // end class HomeController
} // end BoardAppDB.Controllers