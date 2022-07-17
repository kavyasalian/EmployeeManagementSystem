using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
