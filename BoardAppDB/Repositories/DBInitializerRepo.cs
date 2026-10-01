// Group leader name : Kabelo Nhlapho
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this class is to implement IDBInitializer using the
//                     Repository pattern, creating the SQLite database if it does not exist
//                     and seeding the Board table only when it is empty.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo : IDBInitializer
    {
        // database context received through constructor injection
        private readonly BoardContext context;

        public DBInitializerRepo(BoardContext context)
        {
            //
            //Name             : DBInitializerRepo(BoardContext context)
            //Purpose          : Overloaded constructor that receives the database context
            //                   through constructor injection
            //Re-use           : None
            //Method Parameters: BoardContext context
            //                   database context registered in Program.cs
            //Output Type      : None
            //
            this.context = context;
        } // end method

        public void Initialize()
        {
            //
            //Name             : void Initialize()
            //Purpose          : Creates the database if it does not exist and seeds the
            //                   Board table only if it contains no records, so running the
            //                   application more than once never duplicates the seed data
            //Re-use           : None
            //Method Parameters: None
            //Output Type      : None
            //
            context.Database.EnsureCreated();

            if (!context.Boards.Any())
            {
                var boards = new List<Board>()
                {
                    new Board("1001", "Espressif", "ESP32-WROOM-32", 4096, 129.00m),
                    new Board("1002", "Espressif", "ESP32-C3-MINI-1", 4096, 99.00m),
                    new Board("1003", "STMicroelectronics", "STM32F103C8T6", 64, 75.00m),
                    new Board("1004", "STMicroelectronics", "STM32F411CEU6", 512, 145.00m),
                    new Board("1005", "Microchip", "ATmega328P", 32, 89.00m),
                    new Board("1006", "Microchip", "ATmega2560", 256, 199.00m),
                    new Board("1007", "WCH", "CH32V003F4P6", 16, 29.00m),
                    new Board("1008", "Raspberry Pi", "Pico", 2048, 89.00m),
                    new Board("1009", "Espressif", "ESP-01S", 1024, 65.00m),
                    new Board("1010", "CUTfree", "CV32-BFN-01", 128, 49.00m)
                };

                context.Boards.AddRange(boards);
                context.SaveChanges();
            } // end if
        } // end method
    } // end class DBInitializerRepo
} // end BoardAppDB.Repositories