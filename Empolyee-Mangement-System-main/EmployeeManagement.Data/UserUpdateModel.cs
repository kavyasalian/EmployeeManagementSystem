using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class UserUpdateModel
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public int RoleId { get; set; }


    }
}
