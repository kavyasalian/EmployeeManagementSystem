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
