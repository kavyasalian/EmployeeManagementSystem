using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Company
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Isdeleted { get; set; }
    }
}
