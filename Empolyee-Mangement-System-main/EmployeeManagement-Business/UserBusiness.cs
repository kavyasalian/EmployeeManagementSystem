using EmployeeManagement.Data;
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
            this.userRepository = new UserRepository();
        }

        public async Task<List<UserGetModel>> GetUsersListByIdAsync()
        {
            var users = userRepository.GetAllUsersAsync();
            var userModel = new List<UserGetModel>();
            foreach (var employee in users)
            {
                var user = new UserGetModel();
                user.FirstName = employee.FirstName;
                user.LastName = employee.LastName;
                user.Email = employee.Email;
                user.Phone = employee.Phone;

                userModel.Add(user);
            }
           return userModel;
        }
        public async Task<UserGetModel> GetUserByIdAsync(int Id)
        {
            var user = await userRepository.GetUserById(Id);
            var userModel = new UserGetModel();
            if (user != null)
            {
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.Email = user.Email;
                userModel.Phone = user.Phone;

            }
            return userModel;
        }
    }
}
