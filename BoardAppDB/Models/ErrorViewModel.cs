// Group leader name : Kabelo Nhlapho
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this class is to hold the request information
//                     displayed on the error page.

namespace BoardAppDB.Models
{
    public class ErrorViewModel
    {
        public string? RequestId
        {
            //
            //Name             : property string? RequestId
            //Purpose          : Automatic public property to give access to corresponding compiler generated field
            //Re-use           : none
            //Input Parameter  : string? value
            //                   new value for corresponding compiler generated field
            //Output Type      : string?
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        //
        //Name             : property bool ShowRequestId
        //Purpose          : Read-only property indicating whether the request ID must be shown
        //Re-use           : none
        //Input Parameter  : none
        //Output Type      : bool
        //                   true if RequestId contains a value, false otherwise
        //
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // end property
    } // end class ErrorViewModel
} // end BoardAppDB.Models
