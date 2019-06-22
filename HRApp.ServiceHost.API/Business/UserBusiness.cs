using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Data;
using HRApp.ServiceHost.API.Helpers;
using HRApp.ServiceHost.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        public UserBusiness(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// new record  user
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns> Task User class</returns>
        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }
        /// <summary>
        /// jwt token and User token
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>Task<User></returns>
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _userRepository.Authenticate(username, password);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name,user.id.ToString()),
                    new Claim(ClaimTypes.Role,user.role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            user.password = null;
            return user;
        }
        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns>Task<UserResponse></returns>
        public async Task<UserResponse> GetAllAsync()
        {
            IEnumerable<User> user = await _userRepository.GetAllAsync();
            var response = new UserResponse();
            if (user.ToList().Count == 0)
                response.Message = "Kayıt bulunamadı !";
            else
                response.Users.AddRange(user);
            return response;

        }
        /// <summary>
        /// user info , get by user id 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns> Task<UserResponse></returns>
        public async Task<UserResponse> GetAsync(long id)
        {
            UserResponse response = new UserResponse();
            var usr = await _userRepository.GetAsync(id);

            if (usr == null)
                response.Message = "Kayıt bulunamadı !";
            else
                response.Users.Add(usr);
            return response;
        }
        /// <summary>
        /// user update
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task User class</returns>
        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
