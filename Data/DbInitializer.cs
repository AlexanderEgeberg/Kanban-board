using System.Linq;
using Kanban_board.Models;

namespace Kanban_board.Data
{
    public static class DbInitializer
    {
        public static void Initialize(KanbanContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Boards.Any())
            {
                return;   // DB has been seeded
            }


            var boards = new Board[]
            {
                new Board{BoardName = "Board 1"},
                new Board{BoardName = "Board 2"},
            };
            foreach (Board b in boards)
            {
                context.Boards.Add(b);
            }
            context.SaveChanges();



            var userstories = new Userstory[]
            {
                new Userstory{ boardId = 1, Description = "test1", Status = Userstory.kanbanStatus.Doing, Title = "titletest1"},
                new Userstory{ boardId = 1, Description = "test2", Status = Userstory.kanbanStatus.Done, Title = "titletest2"},
                new Userstory{ boardId = 1, Description = "test3", Status = Userstory.kanbanStatus.Todo, Title = "titletest3"}
            };
            foreach (Userstory u in userstories)
            {
                context.Userstories.Add(u);
            }
            context.SaveChanges();





        }
    }
}
