using System.ComponentModel.DataAnnotations;

namespace Kanban_board.Models
{
    public class Email
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
