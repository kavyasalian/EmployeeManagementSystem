using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRepository
    {
        private readonly EmployeeManagementContext _dbContext;
        public UserRepository()
        {
            this._dbContext = new EmployeeManagementContext();
        }
    }
}
