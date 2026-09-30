using Microsoft.EntityFrameworkCore;
using BoardAppDB.Models;
namespace ASPNETCore_DB.Data
{
    public class SQLiteDBContext : DbContext
    {
        public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options) : base(options)
        { }
        public DbSet<Board>? Boards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Board");
        }
    }
}