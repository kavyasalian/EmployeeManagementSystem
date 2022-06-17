using EmployeeManagement_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Business
{
    public class UserBusiness
    {
        private readonly UserRepository userRepository;

        public UserBusiness()
        {
            this.userRepository = new UserRepository;
        }
    }
}
