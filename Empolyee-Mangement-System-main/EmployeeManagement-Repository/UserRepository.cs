using EmployeeManagement.Data;
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
        public async Task<bool> Create(UserCreateModel user)
        {
            try
            {
                _dbContext.Users.Add(new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email=user.Email,
                    Password=user.Password,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                });

                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
