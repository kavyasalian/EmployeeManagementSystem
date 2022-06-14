using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class EmployeeCreateModel
    {
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
        public String Gender { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String Phone { get; set; } = null!;
        public String DateCreated { get; set; } = null!;
        public String DateModified { get; set; } = null!;
        public int CompanyId { get; set; }
    }
}
