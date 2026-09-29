using Microsoft.EntityFrameworkCore;
using BoardAppDB.Models;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards
        {
            get; set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<Board>()
                .Property(b => b.Price)
                .HasConversion<double>();
        }
    }
}
