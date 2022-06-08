using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
