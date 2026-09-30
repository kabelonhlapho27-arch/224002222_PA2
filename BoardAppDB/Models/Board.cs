// Group leader name : Kabelo Nhlapho
// Group Student nrs : 219005935; 224042163; 224037409; 220048471; 223068452; 224136508; 224069913; 219005935
// Assignment nr     : SOD226C Practical Assessment 1 · 2026
// Purpose           : The purpose of this class is to define the model structure,
//                     validation rules, and properties for microcontroller development boards.

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using BoardAppDB.Infrastructure;

namespace BoardAppDB.Models
{
    public class Board
    {
        [Required(ErrorMessage = "The board code is required")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "The board code must be 4 characters")]
        [Display(Name = "Board Code")]
        [Key]
        public string BoardCode
        {
            //
            //Name             : property string BoardCode
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : string value
            //                   new value for corresponding compiler generated field
            //Output Type      : string
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        [Required(ErrorMessage = "The board manufacturer is required")]
        [Display(Name = "Manufacturer")]
        public string Make
        {
            //
            //Name             : property string Make
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : string value
            //                   new value for corresponding compiler generated field
            //Output Type      : string
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        [Required(ErrorMessage = "The board model is required")]
        [Display(Name = "Model")]
        public string Model
        {
            //
            //Name             : property string Model
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : string value
            //                   new value for corresponding compiler generated field
            //Output Type      : string
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        [Required(ErrorMessage = "The flash size is required")]
        //[Range(16, 4096, ErrorMessage = "The flash size must be between 16 and 4096 inclusive")]
        [Display(Name = "Flash (KB)")]
        [VerifyFlashSize]
        public int? FlashKb
        {
            //
            //Name             : property int? FlashKb
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : int? value
            //                   new value for corresponding compiler generated field
            //Output Type      : int?
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        [Required(ErrorMessage = "The price is required")]
        [Range(1.00, 5000.00, ErrorMessage = "The price must be between R1.00 and R5000.00 inclusive")]
        [Display(Name = "Price (R) ")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal? Price
        {
            //
            //Name             : property decimal? Price
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : decimal? value
            //                   new value for corresponding compiler generated field
            //Output Type      : decimal?
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        public Board()
        {
            //
            //Name             : Board()
            //Purpose          : Default constructor for the Board class
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : None
            //
        } // end method

        public Board(string boardCode, string make, string model, int flashkb, decimal price)
        {
            //
            //Name             : Board(string boardCode, string make, string model, int flashkb, decimal price)
            //Purpose          : Overloaded constructor used to initialize Board properties
            //Re-use           : None
            //Method Parameters: string boardCode
            //                   new value for BoardCode property
            //                   string make
            //                   new value for Make property
            //                   string model
            //                   new value for Model property
            //                   int flashkb
            //                   new value for FlashKb property
            //                   decimal price
            //                   new value for Price property
            //Output Type      : None
            //
            BoardCode = boardCode;
            Make = make;
            Model = model;
            FlashKb = flashkb;
            Price = price;
        } // end method

        public override string ToString()
        {
            //
            //Name             : string ToString()
            //Purpose          : Returns a formatted string representation of the Board object
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : string
            //                   formatted details of the Board instance
            //
            return $"Board Code: {BoardCode}, Make: {Make}, Model: {Model}, Flash Size: {FlashKb}KB, Price: R{Price:0.00}";
        } // end method
    } // end class Board
} // end BoardAppDB.Models