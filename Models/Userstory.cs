using System.ComponentModel.DataAnnotations;

namespace Kanban_board.Models
{
    public class Userstory
    {
        public enum kanbanStatus
        {
            Todo,
            Doing,
            Done
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserstoryId { get; set; }

        [Required(ErrorMessage = "A title is required"), MaxLength(20)]
        public string Title { get; set; }
        public string Description { get; set; }


        [Required(ErrorMessage = "A status is required")]
        public kanbanStatus Status { get; set; }

        public int boardId { get; set; }
        public Board Board { get; set; }


    }
}
