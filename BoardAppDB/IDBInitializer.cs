// Group leader name : Kabelo Nhlapho
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this interface is to define the contract for
//                     creating and seeding the Board App database at application start-up.

namespace BoardAppDB.Interfaces
{
    public interface IDBInitializer
    {
        //
        //Name              : void Initialize()
        //Purpose           : Creates the database if it does not exist and seeds it
        //                    with initial Board data only if the Board table is empty
        //Re-use            : none
        //Method Parameters : none
        //Output Type       : None
        //
        void Initialize();
    } // end interface IDBInitializer
} // end namespace BoardAppDB.Interfaces