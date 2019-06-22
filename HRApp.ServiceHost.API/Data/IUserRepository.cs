using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Data
{
    public interface IUserRepository
    {
        /// <summary>
        /// get by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns> Task<User></returns>
        Task<User> GetAsync(long id);
        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns> Task<IEnumerable<User>></returns>
        Task<IEnumerable<User>> GetAllAsync();
        /// <summary>
        /// new user record
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task User</returns>
        Task AddAsync(User user);
        /// <summary>
        /// update User
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task User</returns>
        Task UpdateAsync(User user);
        /// <summary>
        ///   jwt token and User class
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns> Task<User></returns>
        Task<User> Authenticate(string username, string password);
    }
}
