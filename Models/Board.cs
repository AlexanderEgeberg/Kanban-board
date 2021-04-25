using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanban_board.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Board name is required"), MaxLength(20)]

        public string BoardName { get; set; }

        public ICollection<Userstory> Userstories { get; set; }
    }
}
