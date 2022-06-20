using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public  async Task<HttpStatusCode> UpdateUserAsync(UserUpdateModel userView)
        {
            var user = new UserUpdateModel
            {
                UserId = userView.UserId,
                UserFirstName = userView.UserFirstName,
                UserLastName = userView.UserLastName,
                UserEmail = userView.UserEmail,
                UserPhone = userView.UserPhone,
            };
            var status = await userRepository.Update(user);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }

        }

        public  async Task<HttpStatusCode> DeleteUserAsync(int userId)
        {
            var status = await userRepository.Delete(userId);
            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
    }
}
