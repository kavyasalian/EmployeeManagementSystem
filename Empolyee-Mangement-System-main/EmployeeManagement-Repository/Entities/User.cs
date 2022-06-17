using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class User

    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int UserPhone { get; set; }
        public string UserEmail { get; set; }
        public int RoleId { get; set; }
    }
}
