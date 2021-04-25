using System.Collections.Generic;

namespace Kanban_board.ViewModel
{
    public class DisplayVm
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersVm> Users { get; set; }
    }
}
