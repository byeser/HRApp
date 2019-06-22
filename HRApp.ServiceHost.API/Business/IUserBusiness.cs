using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
    public interface IUserBusiness
    {
        /// <summary>
        /// get user info by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>Task<UserResponse></returns>
        Task<UserResponse> GetAsync(long id);
        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns> Task<UserResponse></returns>
        Task<UserResponse> GetAllAsync();
        /// <summary>
        /// new record user
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task user class</returns>
        Task AddAsync(User user);
        /// <summary>
        /// user info update
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Task user class</returns>
        Task UpdateAsync(User user);
        /// <summary>
        /// jwt token and User class
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>Task<User></returns>
        Task<User> Authenticate(string username, string password);
    }
}
