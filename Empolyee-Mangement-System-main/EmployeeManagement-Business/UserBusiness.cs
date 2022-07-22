using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using EmployeeManagement_Repository.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
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

        public async Task<List<UserGetModel>> GetAllUsersAsync()
        {
            var users = userRepository.GetAllUsersAsync();
            var userModel = new List<UserGetModel>();
            foreach (var employee in users)
            {
                var user = new UserGetModel();
                user.Id = employee.UserId;
                user.FirstName = employee.FirstName;
                user.LastName = employee.LastName;
                user.Email = employee.Email;
                user.Password = employee.Password;
                user.Phone = employee.Phone;
                user.RoleId = employee.RoleId;

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
                userModel.Id = Id;
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.Email = user.Email;
                userModel.Password = user.Password;
                userModel.Phone = user.Phone;
                userModel.RoleId = user.RoleId;


                return userModel;
            }
            return null;
        }

        public async Task<HttpStatusCode> UpdateUserAsync(UserUpdateModel userView)
        {

            var status = await userRepository.Update(userView);
            if (status)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }

        }

        public async Task<HttpStatusCode> DeleteUserAsync(int userId)
        {
            var status = await userRepository.Delete(userId);
            return status ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }
        public async Task<HttpStatusCode> SaveUserAsync(UserCreateModel user)
        {
            var status = await userRepository.Create(user);

            if (status)
            {
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public async Task<AuthenticationModel> Login(LoginModel loginmodel)
        {
            var login = await userRepository.Login(loginmodel.UserEmail, loginmodel.Password);

            var authmodel = new AuthenticationModel();
            if (login != null)
            {
                authmodel.Name = login.FirstName;
                authmodel.UserId = login.UserId;
                authmodel.Email = login.Email;
                return authmodel;
            }

            return null;
        }

        public async Task PopulateJwtTokenAsync(AuthenticationModel authModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, authModel.UserId.ToString()),
                        new Claim(ClaimTypes.Email, authModel.Email.ToString()),
                        new Claim(ClaimTypes.Name, authModel.Name.ToString())
                }),
                Expires = authModel.TokenExpiryDate = DateTime.UtcNow.AddMinutes(50),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            authModel.Token = tokenHandler.WriteToken(token);
        }
    }
}
