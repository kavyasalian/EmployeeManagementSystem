using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public  class ProjectCreateModel
    {
        public String ProjectName { get; set; } = null!;
        public String ProjectDesc { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
