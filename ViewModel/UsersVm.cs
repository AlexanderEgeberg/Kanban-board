using System.Collections.Generic;
using Kanban_board.Models;

namespace Kanban_board.ViewModel
{
    public class UsersVm
    {
        public string Email { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
