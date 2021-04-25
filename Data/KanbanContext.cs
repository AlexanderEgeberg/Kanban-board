using Kanban_board.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanban_board.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options)
        {
        }

        public DbSet<Userstory> Userstories { get; set; }
        public DbSet<Board> Boards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Userstory>().ToTable("Userstory");
            modelBuilder.Entity<Board>().ToTable("Board");

        }
    }
}
