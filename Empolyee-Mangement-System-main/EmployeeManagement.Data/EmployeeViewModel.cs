using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class EmployeeViewModel
    {
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; }=null;
        public string Gender { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
    }
}
