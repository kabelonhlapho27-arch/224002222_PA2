// Group leader name : Kabelo Nhlapho
// Group Student nrs : 224042163; 220048471; 219005935; 224136508; 224069913; 223068452; 224037409
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this interface is to define the contract for
//                     creating and seeding the Board App database at application start-up.

using BoardAppDB.Data;

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
