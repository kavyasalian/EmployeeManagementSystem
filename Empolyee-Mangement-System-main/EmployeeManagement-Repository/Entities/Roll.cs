using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeManagement_Repository.Entities
{
    public partial class Roll
    {
        public int RollId { get; set; }
        public string RollName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
