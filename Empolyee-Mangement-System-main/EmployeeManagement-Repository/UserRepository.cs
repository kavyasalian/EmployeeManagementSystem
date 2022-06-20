using EmployeeManagement_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_Repository
{
    public class UserRepository
    {
        private readonly EmployeeManagementContext dbContext;
        public UserRepository()
        {
            this.dbContext = new EmployeeManagementContext();
        }
        public List<User> GetAllUsersAsync()
        {
            return dbContext.Users.ToList();

        }
        public async Task<User> GetUserById(int Id)
        {
            return dbContext.Users.FirstOrDefault(x => x.UserId == Id);
        }


    }
}
