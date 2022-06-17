using System;
using System.Collections.Generic;
namespace EmployeeManagement_Repository.Entities
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
