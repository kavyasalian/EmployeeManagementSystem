using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeManagement.Data;
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
        public async Task<bool> Update(UserUpdateModel user)
        {

            var existingUser = _dbContext.Users.Where(a => a.UserId == user.UserId).FirstOrDefault();

            if (existingUser != null)
            {
                existingUser.FirstName = user.UserFirstName;
                existingUser.LastName = user.UserLastName;
                existingUser.Email = user.UserEmail;
                existingUser.Phone = user.UserPhone;
                existingUser.RoleId = user.RoleId;
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int UserId)
        {
            var user = await GetById(UserId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        private async Task<User> GetById(int UserId)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserId == UserId);
        }
    }
}
