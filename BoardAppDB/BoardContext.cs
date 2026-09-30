// Group leader name : Kabelo Nhlapho
// Group Student nrs : 220048471; <student nr>; <student nr>
// Assignment nr     : SOD226C Practical Assessment 2 · 2026
// Purpose           : The purpose of this class is to act as the Entity Framework Core
//                     database context for the Board App, exposing the Boards DbSet and
//                     mapping the Board entity to the Board table in the SQLite database.

using Microsoft.EntityFrameworkCore;
using BoardAppDB.Models;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
            //
            //Name             : BoardContext(DbContextOptions<BoardContext> options)
            //Purpose          : Overloaded constructor that passes the configured database
            //                   options (SQLite provider and connection string) to the base class
            //Re-use           : DbContext(DbContextOptions options)
            //Method Parameters: DbContextOptions<BoardContext> options
            //                   options used to configure the database context
            //Output Type      : None
            //
        } // end method

        public DbSet<Board> Boards
        {
            //
            //Name             : property DbSet<Board> Boards
            //Purpose          : Automatic public property that gives access to the collection
            //                   of Board entities stored in the Board table
            //Re-use           : none
            //Input Parameter  : DbSet<Board> value
            //                   new value for corresponding compiler generated field
            //Output Type      : DbSet<Board>
            //                   value stored in the corresponding compiler generated field
            //
            get; set;
        } // end property

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            //Name             : void OnModelCreating(ModelBuilder modelBuilder)
            //Purpose          : Configures the model by mapping the Board entity to the Board
            //                   table and storing the decimal Price as a double so that SQLite
            //                   sorts and compares prices numerically instead of as text
            //Re-use           : none
            //Method Parameters: ModelBuilder modelBuilder
            //                   builder used to configure the entity model
            //Output Type      : None
            //
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<Board>()
                .Property(b => b.Price)
                .HasConversion<double>();
        } // end method
    } // end class BoardContext
} // end BoardAppDB.Data