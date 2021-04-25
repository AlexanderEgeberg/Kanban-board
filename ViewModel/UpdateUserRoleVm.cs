using System.Collections.Generic;

namespace Kanban_board.ViewModel
{
    public class UpdateUserRoleVm
    {
        public IEnumerable<UsersVm> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string UserEmail { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
}
